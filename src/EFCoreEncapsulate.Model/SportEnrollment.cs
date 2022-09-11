namespace EFCoreEncapsulate.Model;

public class SportEnrollment : Entity
{
    public Grade Grade { get; set; }

    public long SportId { get; set; }

    public virtual Sport Sport { get; set; }

    public long StudentId { get; set; }

    public virtual Student Student { get; set; }
}
