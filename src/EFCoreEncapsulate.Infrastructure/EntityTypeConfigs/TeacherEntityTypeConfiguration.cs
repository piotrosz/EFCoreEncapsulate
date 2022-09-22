using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Infrastructure.EntityTypeConfigs;

public class TeacherEntityTypeConfiguration : IEntityTypeConfiguration<Teacher>
{
    public void Configure(EntityTypeBuilder<Teacher> builder)
    {    
        builder.ToTable("Teacher").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("TeacherID");
    }
}