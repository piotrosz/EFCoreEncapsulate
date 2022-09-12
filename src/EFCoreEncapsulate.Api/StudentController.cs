using EFCoreEncapsulate.Data;
using EFCoreEncapsulate.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulate.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly SchoolContext _schoolContext;
    private readonly StudentRepository _studentRepository;
    private readonly CourseRepository _courseRepository;
    

    public StudentController(
        StudentRepository studentRepository,
        CourseRepository courseRepository, 
        SchoolContext schoolContext)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _schoolContext = schoolContext;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> Get(long id)
    {
        Student student = await _studentRepository.GetByIdOrNullAsync(id);

        if (student == null)
        {
            return null;
        }

        return new StudentDto
        {
            StudentId = student.Id,
            Name = student.Name,
            Email = student.Email,
            CourseEnrollments = student.CourseEnrollments.Select(x => new CourseEnrollmentDto
            {
                Course = x.Course.Name,
                Grade = x.Grade.ToString()
            }).ToList(),
            SportEnrollments = student.SportEnrollments.Select(x => new SportEnrollmentDto
            {
                Sport = x.Sport.Name,
                Grade = x.Grade.ToString()
            }).ToList()
        };
    }

    [HttpPost]
    public async Task<IActionResult> EnrollInCourse(long studentId, long courseId, Grade grade)
    {
        Student student = await _studentRepository.GetByIdOrNullAsync(studentId);

        if (student == null)
        {
            return NotFound("Student not found");
        }

        Course course = await _courseRepository.GetByIdOrNullAsync(courseId);

        if (course == null)
        {
            return BadRequest("Course not found");
        }

        var result = student.EnrollInCourse(course, grade);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        await _schoolContext.SaveChangesAsync();

        return Ok();
    }
}
