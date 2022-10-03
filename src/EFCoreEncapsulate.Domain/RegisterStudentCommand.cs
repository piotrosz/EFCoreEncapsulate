using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public sealed class RegisterStudentCommand : ICommand
{
    public RegisterStudentCommand(string name, string email)
    {
        Name = name;
        Email = email;
    }
    
    public string Name { get; }
    public string Email { get; }
}