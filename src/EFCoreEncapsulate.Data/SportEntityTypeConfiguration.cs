using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Data;

public class SportEntityTypeConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {           
        builder.ToTable("Sport").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("SportID");
        builder.Property(p => p.Name).HasMaxLength(200);
    }
}


