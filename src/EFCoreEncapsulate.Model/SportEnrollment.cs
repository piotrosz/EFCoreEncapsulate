namespace EFCoreEncapsulate.Model;

public class SportEnrollment
{
    public long Id { get; set; }
    public Grade Grade { get; set; }
    public virtual Sport Sport { get; set; }
    public virtual Student Student { get; set; }
}
