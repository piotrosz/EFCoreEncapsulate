using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.SharedKernel.Configuration;

public interface IModelConfiguration
{
    void ConfigureModel(ModelBuilder modelBuilder);
}
