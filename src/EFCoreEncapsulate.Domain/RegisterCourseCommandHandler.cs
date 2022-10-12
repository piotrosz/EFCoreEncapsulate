using CSharpFunctionalExtensions;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class RegisterCourseCommandHandler : ICommandHandler<RegisterCourseCommand>
{
    private readonly ICourseRepository _courseRepository;

    public RegisterCourseCommandHandler(
        ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Result> HandleAsync(RegisterCourseCommand command)
    {
        if (await _courseRepository.CourseExists(command.Name))
        {
            return Result.Failure("Course with this name exists");
        }
        
        await _courseRepository.SaveAsync(new Course(command.Name));
        await _courseRepository.SaveChangesAsync();

        return Result.Success();
    }
}