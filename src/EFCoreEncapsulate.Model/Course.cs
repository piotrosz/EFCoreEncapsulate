namespace EFCoreEncapsulate.Model;

public class Course : Entity
{
    public string Name { get; set; }

    public ICollection<Teacher> Teachers { get; set; }
}
