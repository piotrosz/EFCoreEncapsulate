using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Data
{
    public class StudentRepository : Repository
    {
        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
        }

        public async Task<Student?> GetByIdOrNullAsync(long id)
        {
            //return _schoolContext.Students.SingleOrDefault(x => x.Id == id);

            // only Find() reads from cache (AutoInclude)
            // good practice to use it whenever possible
            return await SchoolContext.Students.FindAsync(id);
        }

        // Avoiding Cartesian explosion by using AsSplitQuery() and no AutoInclude (first approach)
        public Student? GetByIdOrNull_SplitQueries(long id)
        {
            return SchoolContext.Students
                .Include(x => x.CourseEnrollments)
                .ThenInclude(x => x.Course)
                .Include(x => x.SportEnrollments)
                .ThenInclude(x => x.Sport)
                .AsSplitQuery()
                .SingleOrDefault(x => x.Id == id);
        }

        // Avoiding Cartesian explosion by explicitly loading related collections and no AutoInclude (second approach)
        // Produces cleaner SQL queries than AsSplitQuery
        public Student? GetByIdOrNull_ExplicitLoading(long id)
        {
            Student? student = SchoolContext.Set<Student>().Find(id);

            if (student == null)
                return null;

            SchoolContext.Entry(student).Collection(x => x.CourseEnrollments).Load();
            SchoolContext.Entry(student).Collection(x => x.SportEnrollments).Load();

            return student;
        }
    }
}
