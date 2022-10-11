using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public sealed class RegisterCourseCommand : ICommand
{
    public RegisterCourseCommand(string name)
    {
        Name = name;
    }
    
    public string Name { get; }
}