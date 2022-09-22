namespace EFCoreEncapsulate.Domain;

public class SportEnrollment : Entity
{
    protected SportEnrollment()
    {
        
    }
    
    public SportEnrollment(long id, long studentId, long sportId, Grade grade)
    {
        Id = id;
        StudentId = studentId;
        SportId = sportId;
        Grade = grade;
    }

    public Grade Grade { get; set; }

    public long SportId { get; set; }

    //public virtual Sport Sport { get; set; }

    public long StudentId { get; set; }

    public virtual Student Student { get; set; }
}
