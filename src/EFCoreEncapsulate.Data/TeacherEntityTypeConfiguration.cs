using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Data;

public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {    
        builder.ToTable("Teacher").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("TeacherID");
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
        builder.HasMany(p => p.Courses).WithMany(p => p.Teachers);
    
    }
}
