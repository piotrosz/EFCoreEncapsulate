using CSharpFunctionalExtensions;

namespace EFCoreEncapsulate.Domain;

// Aggregate
public class Student : Entity
{
    // EF needs this constructor
    protected Student()
    {
    }
    
    public Student(long id, string name, Email email)
    {
        Id = id;
        Name = name;
        Email = email;
    }
    
    public Student(string name, Email email)
    {
        Name = name;
        Email = email;
    }

    public string Name { get; set; }
    public Email Email { get; set; }
    
    public ICollection<CourseEnrollment> CourseEnrollments { get; protected set; }

    public ICollection<SportEnrollment> SportEnrollments { get; protected set; }

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
