using CSharpFunctionalExtensions;

namespace EFCoreEncapsulate.Model;

// Aggregate
public class Student : Entity
{
    public Student(long id, string name, string email)
    {
        Id = id;
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<CourseEnrollment> CourseEnrollments { get; set; }

    public ICollection<SportEnrollment> SportEnrollments { get; set; }

    public Result EnrollInCourse(Course course, Grade grade)
    {
        // Keeping invariant
        // Without full data (enrollments in this case) aggregate cannot enforce its invariants
        if (CourseEnrollments.Any(x => x.CourseId == course.Id))
        {
            return Result.Failure($"Already enrolled in course '{course.Name}'");
        }

        var enrollment = new CourseEnrollment(this, course, grade);
        CourseEnrollments.Add(enrollment);

        return Result.Success();
    }

}
