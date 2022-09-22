using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Infrastructure.EntityTypeConfigs;

public class StudentEntityTypeConfiguration : IEntityTypeConfiguration<Student>
{
    public void Configure(EntityTypeBuilder<Student> builder)
    {
        builder.ToTable("Student").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("StudentID");

        builder
            .OwnsOne(p => p.Email)
            .Property(x => x.Value)
            .HasColumnName("Email");
    }
}