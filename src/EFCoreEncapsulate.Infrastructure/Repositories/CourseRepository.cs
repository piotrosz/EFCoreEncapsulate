using EFCoreEncapsulate.Model;

namespace EFCoreEncapsulate.Data.Repositories;

public class CourseRepository : Repository<Course>
{
    public CourseRepository(SchoolContext schoolContext) : base(schoolContext)
    {
    }

}