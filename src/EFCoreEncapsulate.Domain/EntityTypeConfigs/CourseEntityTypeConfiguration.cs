using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Domain.EntityTypeConfigs;

public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.HasMany(x => x.Teachers).WithMany(x => x.Courses);
    }
}
