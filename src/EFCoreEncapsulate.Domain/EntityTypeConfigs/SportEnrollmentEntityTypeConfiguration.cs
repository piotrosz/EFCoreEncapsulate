using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Domain.EntityTypeConfigs;

public class SportEnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<SportEnrollment>
{
    public void Configure(EntityTypeBuilder<SportEnrollment> x)
    {
        x.HasOne(p => p.Student).WithMany(p => p.SportEnrollments);
        //x.HasOne(p => p.Sport).WithMany();
        x.Property(p => p.SportId);
        x.Property(p => p.Grade);

        // New auto include feature
        //x.Navigation(p => p.Sport).AutoInclude();}
    }
}


