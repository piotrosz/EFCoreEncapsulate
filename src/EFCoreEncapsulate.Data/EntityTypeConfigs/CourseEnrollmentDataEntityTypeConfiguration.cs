using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Data;

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


