using EFCoreEncapsulate.Domain;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(SchoolContext schoolContext) : base(schoolContext)
    {
    }

    public async Task<IReadOnlyList<Course>> GetAllAsync()
    {
        return await SchoolContext.Set<Course>().ToListAsync();
    }
    
    public async Task<bool> CourseExists(string name)
    {
        return await SchoolContext.Set<Course>().AnyAsync(x => x.Name == name);
    }
}