namespace EFCoreEncapsulate.Model;

public class Student
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<CourseEnrollment> CourseEnrollments { get; set; }

    public ICollection<SportEnrollment> SportEnrollments { get; set; }

}
