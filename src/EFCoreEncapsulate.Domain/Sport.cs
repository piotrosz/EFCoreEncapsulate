namespace EFCoreEncapsulate.Domain;

public class Sport : Entity
{
    protected Sport()
    {
    }
    
    public Sport(long id, string name)
    {
        Id = id;
        Name = name;    
    }

    public string Name { get; set; }
}