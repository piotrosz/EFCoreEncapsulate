using EFCoreEncapsulate.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace EFCoreEncapsulate.Domain.Test;

public class Class1
{
    public Class1()
    {
        var options = new DbContextOptionsBuilder<SchoolContext>()
            .UseInMemoryDatabase(Guid.NewGuid().ToString())
            .Options;
        var context = new SchoolContext(options, new Mock<IModelConfiguration>().Object);
    }
}