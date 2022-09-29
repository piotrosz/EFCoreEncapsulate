using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public sealed class RegisterStudentCommand : ICommand
{
    public string Name { get; }
    public string Email { get; }

    public RegisterStudentCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }
}