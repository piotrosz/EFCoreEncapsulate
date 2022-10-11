using CSharpFunctionalExtensions;
using EFCoreEncapsulate.Domain.Decorators;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

[AuditLog]
[DatabaseRetry]
public class RegisterStudentCommandHandler : ICommandHandler<RegisterStudentCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly SchoolContext _schoolContext;
    
    public RegisterStudentCommandHandler(
        IStudentRepository studentRepository, 
        SchoolContext schoolContext)
    {
        _studentRepository = studentRepository;
        _schoolContext = schoolContext;
    }

    public async Task<Result> HandleAsync(RegisterStudentCommand command)
    {
        var email = Email.Create(command.Email);

        if (email.IsFailure)
        {
            return Result.Failure(email.Error);
        }
        
        await _studentRepository.SaveAsync(new Student(command.Name, email.Value));
        await _schoolContext.SaveChangesAsync();

        return Result.Success();
    }
}