using System.ComponentModel.DataAnnotations;
using EFCoreEncapsulate.Api.Dtos;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.Domain;
using EFCoreEncapsulate.Infrastructure;
using EFCoreEncapsulate.Infrastructure.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulate.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly SchoolContext _schoolContext;
    private readonly StudentRepository _studentRepository;
    private readonly CourseRepository _courseRepository;

    private readonly Messages _messages;
    
    public StudentController(
        StudentRepository studentRepository,
        CourseRepository courseRepository, 
        SchoolContext schoolContext, 
        Messages messages)
    {
        _studentRepository = studentRepository;
        _courseRepository = courseRepository;
        _schoolContext = schoolContext;
        _messages = messages;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> Get(long id)
    {
        StudentDto student = await _studentRepository.GetStudentDtoOrNullAsync(id);

        if (student == null)
        {
            return NotFound("Student not found");
        }

        return Ok(student);
    }

     [HttpGet]
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> Get()
    {
        var students = await _studentRepository.GetAllStudentsDtoAsync();

        return Ok(students);
    }

    [HttpPost]
    public async Task<ActionResult> EnrollInCourse(
        [FromBody, Required]EnrollInCourseDto enrollInCourse)
    {
        Student student = await _studentRepository.GetByIdOrNullAsync(enrollInCourse.StudentId);

        if (student == null)
        {
            return NotFound("Student not found");
        }

        Course course = await _courseRepository.GetByIdOrNullAsync(enrollInCourse.CourseId);

        if (course == null)
        {
            return BadRequest("Course not found");
        }

        var result = student.EnrollInCourse(course, enrollInCourse.Grade);

        if (result.IsFailure)
        {
            return BadRequest(result.Error);
        }

        // Not using custom unit of work to avoid shallow abstraction
        // SchoolContext is already a unit of work
        await _schoolContext.SaveChangesAsync();

        return Ok();
    }

    // TODO: name and email validation (FluentValidation)
    [HttpPost]
    public async Task<ActionResult> EditPersonalInfo(long studentId, string name, string email)
    {
        var result = await _messages.DispatchAsync(new EditStudentPersonalInfoCommand(studentId, name, email));
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    // AutoMapper could be used
    //private static StudentDto MapToDto(Student student)
    //{
    //    return new StudentDto
    //    {
    //        StudentId = student.Id,
    //        Name = student.Name,
    //        Email = student.Email,
    //        CourseEnrollments = student.CourseEnrollments.Select(x => new CourseEnrollmentDto
    //        {
    //            Course = x.Course.Name,
    //            Grade = x.Grade.ToString()
    //        }).ToList(),
    //        SportEnrollments = student.SportEnrollments.Select(x => new SportEnrollmentDto
    //        {
    //            Sport = x.Sport.Name,
    //            Grade = x.Grade.ToString()
    //        }).ToList()
    //    };
    //}
}
