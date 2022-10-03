﻿using EFCoreEncapsulate.Domain;

namespace EFCoreEncapsulate.Infrastructure.Repositories;

public class CourseRepository : Repository<Course>, ICourseRepository
{
    public CourseRepository(SchoolContext schoolContext) : base(schoolContext)
    {
    }

}