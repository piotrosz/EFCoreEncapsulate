using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Infrastructure.EntityTypeConfigs;

public class SportEntityTypeConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {           
        builder.ToTable("Sport").HasKey(k => k.Id);
        builder.Property(p => p.Id).HasColumnName("SportID");
    }
}
