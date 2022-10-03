using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public sealed class EnrollInCourseCommand : ICommand
{
    public EnrollInCourseCommand(long studentId, long courseId, Grade grade)
    {
        StudentId = studentId;
        CourseId = courseId;
        Grade = grade;
    }

    public long StudentId { get; }
    
    public long CourseId { get; }

    public Grade Grade { get; set; }
}