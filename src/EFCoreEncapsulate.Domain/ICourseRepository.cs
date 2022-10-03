namespace EFCoreEncapsulate.Domain;

public interface ICourseRepository
{
    Task<Course?> GetByIdOrNullAsync(long id);
    Task SaveAsync(Course entity);
}