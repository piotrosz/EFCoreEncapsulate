using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Data;

public class SportEnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<SportEnrollment>
{
    public void Configure(EntityTypeBuilder<SportEnrollment> x)
    {           
        x.ToTable("SportEnrollment").HasKey(k => k.Id);
        x.Property(p => p.Id).HasColumnName("SportEnrollmentID");
        x.HasOne(p => p.Student).WithMany(p => p.SportEnrollments);
        //x.HasOne(p => p.Sport).WithMany();
        x.Property(p => p.SportId);
        x.Property(p => p.Grade);

        // New auto include feature
        //x.Navigation(p => p.Sport).AutoInclude();}
    }
}


