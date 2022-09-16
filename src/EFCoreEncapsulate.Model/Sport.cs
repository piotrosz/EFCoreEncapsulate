namespace EFCoreEncapsulate.Model;

public class Sport : Entity
{
    public Sport(long id, string name)
    {
        Id = id;
        Name = name;    
    }

    public string Name { get; set; }
}