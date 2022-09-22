using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Infrastructure.EntityTypeConfigs;

public class CourseEntityTypeConfiguration : IEntityTypeConfiguration<Course>
{
    public void Configure(EntityTypeBuilder<Course> builder)
    {       
        builder.ToTable("Course").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("CourseID");
    }
}