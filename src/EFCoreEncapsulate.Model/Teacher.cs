namespace EFCoreEncapsulate.Model;

public class Teacher : Entity
{
    public string Name { get; set; }

    public ICollection<Course> Courses;
}
