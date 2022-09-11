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
            Enrollments = student.Enrollments.Select(x => new EnrollmentDto
            {
                Course = x.Course.Name,
                Grade = x.Grade.ToString()
            }).ToList()
        };
    }
}
