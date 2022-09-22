namespace EFCoreEncapsulate.Domain;

public class CourseEnrollment : Entity
{
    protected CourseEnrollment()
    {
    }
    
    public CourseEnrollment(long id, long studentId, long courseId, Grade grade)
    {
        Id = id;
        StudentId = studentId;
        CourseId = courseId;
        Grade = grade;
    }

    public CourseEnrollment(Student student, Course course, Grade grade)
    {
        StudentId = student.Id;
        CourseId = course.Id;
        Grade = grade;
    }

    public Grade Grade { get; set; }

    public virtual long CourseId { get; set; }
    //public virtual Course Course { get; set; }


    public virtual long StudentId { get; set; }
    public virtual Student Student { get; set; }
}
