using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Domain.EntityTypeConfigs;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder
            .OwnsOne(p => p.Email)
            .Property(x => x.Value)
            .HasMaxLength(150).IsRequired();
            
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.HasMany(p => p.CourseEnrollments).WithOne(p => p.Student);
        builder.HasMany(p => p.SportEnrollments).WithOne(p => p.Student);

        // New auto include feature
        builder.Navigation(p => p.CourseEnrollments).AutoInclude();
        builder.Navigation(p => p.SportEnrollments).AutoInclude();
    }
}
