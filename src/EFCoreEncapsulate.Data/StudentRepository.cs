﻿using EFCoreEncapsulate.Model;
using Microsoft.EntityFrameworkCore;

namespace EFCoreEncapsulate.Data
{
    public class StudentRepository
    {
        private readonly SchoolContext _schoolContext;
        public StudentRepository(SchoolContext schoolContext)
        {
            _schoolContext = schoolContext;
        }

        public Student? GetByIdOrNull(long id)
        {
            //return _schoolContext.Students.SingleOrDefault(x => x.Id == id);

            // only Find() reads from cache (AutoInclude)
            // good practice to use it whenever possible
            return _schoolContext.Students.Find(id);
        }

        // Avoiding Cartesian explosion by using AsSplitQuery() and no AutoInclude (first approach)
        public Student? GetByIdOrNull_SplitQueries(long id)
        {
            return _schoolContext.Students
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
            Student? student = _schoolContext.Set<Student>().Find(id);

            if (student == null)
                return null;

            _schoolContext.Entry(student).Collection(x => x.CourseEnrollments).Load();
            _schoolContext.Entry(student).Collection(x => x.SportEnrollments).Load();

            return student;
        }
    }
}
