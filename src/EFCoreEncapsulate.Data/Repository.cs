namespace EFCoreEncapsulate.Data;

public abstract class Repository
{
    protected readonly SchoolContext SchoolContext;

    protected Repository(SchoolContext schoolContext)
    {
        SchoolContext = schoolContext;
    }
}