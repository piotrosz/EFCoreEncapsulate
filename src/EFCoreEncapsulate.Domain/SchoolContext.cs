using EFCoreEncapsulate.Data.EntityTypeConfigs;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Data;

public sealed partial class SchoolContext : DbContext
{
    // Using this DbContext options you can separate domain from infrastructure
    public SchoolContext(DbContextOptions<SchoolContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .ApplyConfigurationsFromAssembly(typeof(StudentEntityTypeConfiguration).Assembly);
        //.SeedTestData();
    }
    
    // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    // {
    // }
}
