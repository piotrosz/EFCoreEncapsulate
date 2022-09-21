using EFCoreEncapsulate.Model;

namespace EFCoreEncapsulate.Data.Repositories;

public abstract class Repository<T> where T : Entity
{
    protected readonly SchoolContext SchoolContext;

    protected Repository(SchoolContext schoolContext)
    {
        SchoolContext = schoolContext;
    }

    // only Find() reads from cache (AutoInclude)
    // good practice to use it whenever possible
    public virtual async Task<T?> GetByIdOrNullAsync(long id)
    {
        return await SchoolContext.Set<T>().FindAsync(id);
    }

    public virtual async Task SaveAsync(T entity)
    {
        await SchoolContext.Set<T>().AddAsync(entity);
    }
}