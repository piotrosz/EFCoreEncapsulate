using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Infrastructure.EntityTypeConfigs;

public class SportEnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<SportEnrollment>
{
    public void Configure(EntityTypeBuilder<SportEnrollment> x)
    {           
        x.ToTable("SportEnrollment").HasKey(k => k.Id);
        x.Property(p => p.Id).HasColumnName("SportEnrollmentID");
        
        // New auto include feature
        //x.Navigation(p => p.Sport).AutoInclude();}
    }
}