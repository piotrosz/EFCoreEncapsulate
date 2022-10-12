namespace EFCoreEncapsulate.Domain;

public interface ICourseRepository
{
    Task<Course?> GetByIdOrNullAsync(long id);
    Task SaveAsync(Course entity);

    Task<IReadOnlyList<Course>> GetAllAsync();

    Task<bool> CourseExists(string name);

    Task<int> SaveChangesAsync();
}