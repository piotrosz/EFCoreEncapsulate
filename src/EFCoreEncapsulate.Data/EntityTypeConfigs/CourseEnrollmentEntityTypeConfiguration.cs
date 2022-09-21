using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Data.EntityTypeConfigs;

public class CourseEnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<CourseEnrollment>
{
    public void Configure(EntityTypeBuilder<CourseEnrollment> x)
    {           

        x.ToTable("CourseEnrollment").HasKey(k => k.Id);
        x.Property(p => p.Id).HasColumnName("CourseEnrollmentID");
        x.HasOne(p => p.Student).WithMany(p => p.CourseEnrollments);
        //x.HasOne(p => p.Course).WithMany();
        x.Property(p => p.CourseId); // No Course navigation property
        x.Property(p => p.Grade);

        // New auto include feature
        // x.Navigation(p => p.Course).AutoInclude();
    }
}


