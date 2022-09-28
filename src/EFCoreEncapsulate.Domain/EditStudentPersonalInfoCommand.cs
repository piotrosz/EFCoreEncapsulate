namespace EFCoreEncapsulate.Domain;

public sealed class EditStudentPersonalInfoCommand : ICommand
{
    public long Id { get; }
    public string Name { get; }
    public string Email { get; }

    public EditStudentPersonalInfoCommand(long id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
}