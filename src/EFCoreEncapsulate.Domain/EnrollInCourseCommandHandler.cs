using CSharpFunctionalExtensions;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class EnrollInCourseCommandHandler : ICommandHandler<EnrollInCourseCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly ICourseRepository _courseRepository;
    private readonly SchoolContext _schoolContext;

    public EnrollInCourseCommandHandler(
        IStudentRepository studentRepository, 
        SchoolContext schoolContext, 
        ICourseRepository courseRepository)
    {
        _studentRepository = studentRepository;
        _schoolContext = schoolContext;
        _courseRepository = courseRepository;
    }

    public async Task<Result> HandleAsync(EnrollInCourseCommand command)
    {
        Student? student = await _studentRepository.GetByIdOrNullAsync(command.StudentId);

        if (student is null)
        {
            return Result.Failure("Student not found");
        }

        Course? course = await _courseRepository.GetByIdOrNullAsync(command.CourseId);

        if (course is null)
        {
            return Result.Failure("Course not found");
        }

        var result = student.EnrollInCourse(course, command.Grade);

        if (result.IsSuccess)
        {
            await _schoolContext.SaveChangesAsync();    
        }

        return result;
    }
}