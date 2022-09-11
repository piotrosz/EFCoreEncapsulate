namespace EFCoreEncapsulate.Api;

public class StudentDto
{
    public long StudentId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }

    public List<CourseEnrollmentDto> CourseEnrollments { get; set; }
    public List<SportEnrollmentDto> SportEnrollments { get; set; }
}