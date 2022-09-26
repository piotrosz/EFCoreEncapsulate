using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Domain.Test;

public class Class1
{
    public Class1()
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new SchoolContext(options);
    }
}