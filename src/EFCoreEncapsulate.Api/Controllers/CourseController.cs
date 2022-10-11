using System.ComponentModel.DataAnnotations;
using EFCoreEncapsulate.Api.Dtos;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.Domain;
using EFCoreEncapsulate.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace EFCoreEncapsulate.Api.Controllers;

[ApiController]
[Route("courses")]
public class CourseController : ControllerBase
{
    private readonly Messages _messages;

    public CourseController(
        Messages messages)
    {
        _messages = messages;
    }
    
    [HttpGet]
    public async Task<ActionResult<StudentDto>> Get()
    {
        var result = await _messages.DispatchAsync(
            new GetCoursesQuery());
        return result.IsSuccess ? Ok(result.Value) : BadRequest(result.Error);
    }
    
  
    [HttpPut]
    [Route("register")]
    public async Task<IActionResult> Register([Required, FromBody] RegisterCourseDto course)
    {
        var result = await _messages.DispatchAsync(new RegisterCourseCommand(course.Name));
        return result.IsSuccess ? Ok() : BadRequest(result.Error);
    }
}