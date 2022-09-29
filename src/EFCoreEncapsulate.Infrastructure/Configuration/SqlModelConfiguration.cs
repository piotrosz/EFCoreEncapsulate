using EFCoreEncapsulate.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Infrastructure.Configuration;

internal class SqlModelConfiguration : IModelConfiguration
{
    public void ConfigureModel(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
    }
}