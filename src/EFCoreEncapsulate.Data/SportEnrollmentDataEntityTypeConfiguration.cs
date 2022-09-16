using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EFCoreEncapsulate.Data;

public class SportEnrollmentDataEntityTypeConfiguration : IEntityTypeConfiguration<SportEnrollmentData>
{
    public void Configure(EntityTypeBuilder<SportEnrollmentData> x)
    {           
        x.HasNoKey();
            x.Property(p => p.StudentId);
            x.Property(p => p.Grade);
            x.Property(p => p.SportName);
    }
}


