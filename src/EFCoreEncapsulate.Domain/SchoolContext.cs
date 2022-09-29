using EFCoreEncapsulate.Domain.EntityTypeConfigs;
using EFCoreEncapsulate.SharedKernel.Configuration;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Domain;

public sealed class SchoolContext : DbContext
{
    private readonly IModelConfiguration _modelConfiguration;
    
    // Using this DbContext options you can separate domain from infrastructure
    public SchoolContext(DbContextOptions<SchoolContext> options, 
        IModelConfiguration modelConfiguration) : base(options)
    {
        _modelConfiguration = modelConfiguration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(StudentEntityTypeConfiguration).Assembly);
        //.SeedTestData();
        
        _modelConfiguration.ConfigureModel(modelBuilder);
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    // }
}
