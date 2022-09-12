using EFCoreEncapsulate.Model;

namespace EFCoreEncapsulate.Data;

public class CourseRepository : Repository
{

    public CourseRepository(SchoolContext schoolContext) : base(schoolContext)
    {
    }

    public async Task<Course?> GetByIdOrNullAsync(long id)
    {
        return await SchoolContext.Courses.FindAsync(id);
    }
}