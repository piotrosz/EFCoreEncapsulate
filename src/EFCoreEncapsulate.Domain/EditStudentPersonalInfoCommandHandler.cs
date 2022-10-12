using CSharpFunctionalExtensions;
using EFCoreEncapsulate.Domain.Decorators;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

[AuditLog]
[DatabaseRetry]
public sealed class EditStudentPersonalInfoCommandHandler : ICommandHandler<EditStudentPersonalInfoCommand>
{
    private readonly IStudentRepository _studentRepository;
    private readonly SchoolContext _schoolContext;
        
    public EditStudentPersonalInfoCommandHandler(
        IStudentRepository studentRepository, 
        SchoolContext schoolContext)
    {
        _studentRepository = studentRepository;
        _schoolContext = schoolContext;
    }

    public async Task<Result> HandleAsync(EditStudentPersonalInfoCommand command)
    {
        Student? student = await _studentRepository.GetByIdOrNullAsync(command.Id);

        if (student is null)
        {
            return Result.Failure($"No student found for Id {command.Id}");
        }

        var emailResult = Email.Create(command.Email);

        if (emailResult.IsFailure)
        {
            return emailResult;
        }
        
        student.Name = command.Name;
        student.Email = emailResult.Value;

        await _schoolContext.SaveChangesAsync();

        return Result.Success();
    }
}