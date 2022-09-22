namespace EFCoreEncapsulate.Domain;

// Introduced to experiment with many-to-many relations
public class Teacher : Entity
{
    // EF needs this constructor
    protected Teacher()
    {
    }
    
    public Teacher(long id, string name)
    {
        Id = id;
        Name = name;
    }

    public string Name { get; set; }

    public ICollection<Course> Courses;
}
