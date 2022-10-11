using CSharpFunctionalExtensions;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class RegisterCourseCommandHandler : ICommandHandler<RegisterCourseCommand>
{
    private readonly ICourseRepository _courseRepository;
    private readonly SchoolContext _schoolContext;
    
    public RegisterCourseCommandHandler(
        ICourseRepository courseRepository, 
        SchoolContext schoolContext)
    {
        _courseRepository = courseRepository;
        _schoolContext = schoolContext;
    }

    public async Task<Result> HandleAsync(RegisterCourseCommand command)
    {
        if (await _courseRepository.CourseExists(command.Name))
        {
            return Result.Failure("Course with this name exists");
        }
        
        await _courseRepository.SaveAsync(new Course(command.Name));
        await _schoolContext.SaveChangesAsync();

        return Result.Success();
    }
}