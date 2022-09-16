using EFCoreEncapsulate.Model;

namespace EFCoreEncapsulate.Data;

public class CourseRepository : Repository<Course>
{
    public CourseRepository(SchoolContext schoolContext) : base(schoolContext)
    {
    }

}