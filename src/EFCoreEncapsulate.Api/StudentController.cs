using System.ComponentModel.DataAnnotations;
using EFCoreEncapsulate.Api.Dtos;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.Domain;
using EFCoreEncapsulate.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulate.Api;

[ApiController]
[Route("students")]
public class StudentController : ControllerBase
{
    private readonly Messages _messages;
    
    public StudentController(
        Messages messages)
    {
        _messages = messages;
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<StudentDto>> Get(long id)
    {
        var result = await _messages.DispatchAsync(
            new GetStudentQuery(id));
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<StudentDto>>> Get()
    {
        var result = await _messages.DispatchAsync(
            new GetAllStudentsQuery());
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpPost]
    [Route("enroll")]
    public async Task<ActionResult> EnrollInCourse(
        [FromBody, Required]EnrollInCourseDto enrollInCourse)
    {
        var result = await _messages.DispatchAsync(
            new EnrollInCourseCommand(enrollInCourse.StudentId, enrollInCourse.CourseId, enrollInCourse.Grade));
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    // TODO: name and email validation (FluentValidation)
    [HttpPost]
    [Route("{studentId}")]
    public async Task<ActionResult> EditPersonalInfo(
        long studentId,
        [Required, FromBody] StudentPersonalInfoDto student)
    {
        var result = await _messages.DispatchAsync(
            new EditStudentPersonalInfoCommand(studentId, student.Name, student.Email));
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }

    [HttpPut]
    [Route("register")]
    public async Task<IActionResult> Register([Required, FromBody] RegisterStudentDto student)
    {
        var result = await _messages.DispatchAsync(new RegisterStudentCommand(student.Name, student.Email));
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}
