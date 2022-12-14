using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Domain.EntityTypeConfigs;

public class SportEntityTypeConfiguration : IEntityTypeConfiguration<Sport>
{
    public void Configure(EntityTypeBuilder<Sport> builder)
    {
        builder.Property(p => p.Name).HasMaxLength(200).IsRequired();
    }
}


