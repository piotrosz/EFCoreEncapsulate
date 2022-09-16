namespace EFCoreEncapsulate.Model;

public class Teacher : Entity
{
    public Teacher(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }

    public ICollection<Course> Courses;
}
