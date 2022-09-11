namespace EFCoreEncapsulate.Model;

public class Student : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<CourseEnrollment> CourseEnrollments { get; set; }

    public ICollection<SportEnrollment> SportEnrollments { get; set; }

}
