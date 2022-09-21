using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Data.EntityTypeConfigs;

public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {       
        builder.ToTable("Course").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("CourseID");
        builder.Property(p => p.Name).HasMaxLength(200);

        builder.HasMany(x => x.Teachers).WithMany(x => x.Courses);
    }
}
