using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Infrastructure.EntityTypeConfigs;

public class CourseEnrollmentEntityTypeConfiguration : IEntityTypeConfiguration<CourseEnrollment>
{
    public void Configure(EntityTypeBuilder<CourseEnrollment> x)
    {
        x.ToTable("CourseEnrollment").HasKey(k => k.Id);
        x.Property(p => p.Id).HasColumnName("CourseEnrollmentID");
        //x.HasOne(p => p.Student).WithMany(p => p.CourseEnrollments);
        
        // New auto include feature
        // x.Navigation(p => p.Course).AutoInclude();
    }
}
