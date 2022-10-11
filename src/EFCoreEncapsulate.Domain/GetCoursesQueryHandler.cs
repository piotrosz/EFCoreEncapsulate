using CSharpFunctionalExtensions;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class GetCoursesQueryHandler : IQueryHandler<GetCoursesQuery, Result<IReadOnlyList<CourseDto>>>
{
    private readonly ICourseRepository _courseRepository;

    public GetCoursesQueryHandler(ICourseRepository courseRepository)
    {
        _courseRepository = courseRepository;
    }

    public async Task<Result<IReadOnlyList<CourseDto>>> HandleAsync(GetCoursesQuery query)
    {
        var courses = await _courseRepository.GetAllAsync();

        var dtos = courses.Select(x => new CourseDto()
        {
            CourseId = x.Id,
            Name = x.Name
        });
        
        return Result.Success((IReadOnlyList<CourseDto>)dtos.ToList());
    }
}