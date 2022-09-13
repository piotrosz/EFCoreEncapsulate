using EFCoreEncapsulate.DataContracts;
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
            return await SchoolContext.Set<Student>().FindAsync(id);
        }

        public async Task<StudentDto?> GetStudentDtoOrNullAsync(long id)
        {
            Student? student = await SchoolContext.Set<Student>().FindAsync(id);

            if (student == null)
            {
                return null;
            }

            List<SchoolContext.EnrollmentData> enrollments = SchoolContext.Set<SchoolContext.EnrollmentData>()
                .FromSqlInterpolated($@"
                SELECT e.StudentID, e.Grade, c.Name Course
                FROM dbo.CourseEnrollment e
                INNER JOIN dbo.Course c ON e.CourseID = c.CourseID
                WHERE e.StudentID = {id}")
                .ToList();

            return new StudentDto
            {
                StudentId = id,
                Name = student.Name,
                Email = student.Email,
                CourseEnrollments = enrollments.Select(x => new CourseEnrollmentDto
                {
                    Course = x.Course,
                    Grade = ((Grade)x.Grade).ToString()
                }).ToList()
            };
        }

        // Avoiding Cartesian explosion by using AsSplitQuery() and no AutoInclude (first approach)
        //public Student? GetByIdOrNull_SplitQueries(long id)
        //{
        //    return SchoolContext.Students
        //        .Include(x => x.CourseEnrollments)
        //        .ThenInclude(x => x.Course)
        //        .Include(x => x.SportEnrollments)
        //        .ThenInclude(x => x.Sport)
        //        .AsSplitQuery()
        //        .SingleOrDefault(x => x.Id == id);
        //}

        // Avoiding Cartesian explosion by explicitly loading related collections and no AutoInclude (second approach)
        // Produces cleaner SQL queries than AsSplitQuery
        public async Task<Student?> GetByIdOrNull_ExplicitLoading(long id)
        {
            Student? student = await SchoolContext.Set<Student>().FindAsync(id);

            if (student == null)
            {
                return null;
            }

            await SchoolContext.Entry(student).Collection(x => x.CourseEnrollments).LoadAsync();
            await SchoolContext.Entry(student).Collection(x => x.SportEnrollments).LoadAsync();

            return student;
        }
    }
}
