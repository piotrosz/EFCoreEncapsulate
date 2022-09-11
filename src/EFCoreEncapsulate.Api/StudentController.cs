using EFCoreEncapsulate.Data;
using EFCoreEncapsulate.Model;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulate.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    //private readonly SchoolContext _context;
    private readonly StudentRepository _studentRepository;

    public StudentController(StudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    [HttpGet("{id}")]
    public StudentDto Get(long id)
    {
        Student student = _studentRepository.GetByIdOrNull(id);

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
}
