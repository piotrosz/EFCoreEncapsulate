using EFCoreEncapsulate.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

internal class SqlModelConfiguration : IModelConfiguration
{
    public void ConfigureModel(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlModelConfiguration).Assembly);
    }
}
