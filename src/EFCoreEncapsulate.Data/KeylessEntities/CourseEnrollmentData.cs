namespace EFCoreEncapsulate.Data.KeylessEntities;

// Key-less entity
public class CourseEnrollmentData
{
    public long StudentId { get; set; }
    public int Grade { get; set; }
    public string? CourseName { get; set; }
}
