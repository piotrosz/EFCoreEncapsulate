namespace EFCoreEncapsulate.Model;

public class Course : Entity
{
    public Course(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }

    public ICollection<Teacher> Teachers { get; set; }
}
