using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Data
{
    public class StudentRepository : Repository<Student>
    {
        public StudentRepository(SchoolContext schoolContext) : base(schoolContext)
        {
        }

        public async Task<IReadOnlyList<StudentDto>> GetAllStudentsDtoAsync()
        {
            var students = await SchoolContext.Set<Student>().ToListAsync();

            List<SchoolContext.CourseEnrollmentData> courseEnrollments = await SchoolContext.Set<SchoolContext.CourseEnrollmentData>()
                .FromSqlInterpolated($@"
                    SELECT e.StudentID, e.Grade, c.Name AS CourseName
                    FROM dbo.CourseEnrollment e
                    INNER JOIN dbo.Course c ON e.CourseID = c.CourseId")
                .ToListAsync();

            List<SchoolContext.SportEnrollmentData> sportEnrollments = await SchoolContext.Set<SchoolContext.SportEnrollmentData>()
                .FromSqlInterpolated($@"
                    SELECT e.StudentID, e.Grade, c.Name AS SportName
                    FROM dbo.SportEnrollment e
                    INNER JOIN dbo.Sport c ON e.SportID = c.SportId")
                .ToListAsync();


            return students.Select(x => MapToDto(
                x, 
                courseEnrollments.Where(s => s.StudentId == x.Id).ToList(),
                sportEnrollments.Where(s => s.StudentId == x.Id).ToList()))
                .ToList();
        }

        public async Task<StudentDto?> GetStudentDtoOrNullAsync(long id)
        {
            Student? student = await SchoolContext.Set<Student>().FindAsync(id);

            if (student == null)
            {
                return null;
            }

            IReadOnlyList<SchoolContext.CourseEnrollmentData> courseEnrollments = await SchoolContext.Set<SchoolContext.CourseEnrollmentData>()
                .FromSqlInterpolated($@"
                    SELECT e.StudentID, e.Grade, c.Name AS CourseName
                    FROM dbo.CourseEnrollment e
                    INNER JOIN dbo.Course c ON e.CourseID = c.CourseId
                    WHERE e.StudentID = {id}")
                .ToListAsync();
            
            IReadOnlyList<SchoolContext.SportEnrollmentData> sportEnrollments = await SchoolContext.Set<SchoolContext.SportEnrollmentData>()
                .FromSqlInterpolated($@"
                    SELECT e.StudentID, e.Grade, s.Name AS SportName
                    FROM dbo.SportEnrollment e
                    INNER JOIN dbo.Sport s ON e.SportId = s.SportId
                    WHERE e.StudentID = {id}")
                .ToListAsync();

            return MapToDto(student, courseEnrollments, sportEnrollments);
        }

        private static StudentDto MapToDto(
            Student student, 
            IReadOnlyList<SchoolContext.CourseEnrollmentData> courseEnrollments,
            IReadOnlyList<SchoolContext.SportEnrollmentData> sportEnrollments)
        {
            return new StudentDto
            {
                StudentId = student.Id,
                Name = student.Name,
                Email = student.Email,
                CourseEnrollments = courseEnrollments.Select(x => new CourseEnrollmentDto
                {
                    CourseName = x.CourseName,
                    Grade = ((Grade)x.Grade).ToString()
                }).ToList(),
                SportEnrollments = sportEnrollments.Select(x => new SportEnrollmentDto
                {
                    SportName = x.SportName,
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
