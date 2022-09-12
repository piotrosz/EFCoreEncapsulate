using CSharpFunctionalExtensions;

namespace EFCoreEncapsulate.Model;

public class Student : Entity
{
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<CourseEnrollment> CourseEnrollments { get; set; }

    public ICollection<SportEnrollment> SportEnrollments { get; set; }

    public Result EnrollInCourse(Course course, Grade grade)
    {
        if (CourseEnrollments.Any(x => x.CourseId == course.Id))
        {
            return Result.Failure($"Already enrolled in course '{course.Name}'");
        }

        var enrollment = new CourseEnrollment
        {
            CourseId = course.Id,
            Grade = grade,
            Student = this
        };
        CourseEnrollments.Add(enrollment);

        return Result.Success();
    }

}
