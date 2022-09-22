using EFCoreEncapsulate.Data.KeylessEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Infrastructure.EntityTypeConfigs;

public class CourseEnrollmentDataEntityTypeConfiguration : IEntityTypeConfiguration<CourseEnrollmentData>
{
    public void Configure(EntityTypeBuilder<CourseEnrollmentData> x)
    {           
        x.HasNoKey();
            x.Property(p => p.StudentId);
            x.Property(p => p.Grade);
            x.Property(p => p.CourseName);
    }
}


