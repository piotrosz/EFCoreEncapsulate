namespace EFCoreEncapsulate.Model;

public class Teacher : Entity
{
    public Teacher(long id, string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException($"Parameter „{nameof(name)}” can't be null nor empty", nameof(name));
        }

        if(name.Length > 200)
        {
            throw new ArgumentException($"Name can't have more than {200} characters.");
        }

        Id = id;
        Name = name;
    }

    public string Name { get; set; }

    public ICollection<Course> Courses;
}
