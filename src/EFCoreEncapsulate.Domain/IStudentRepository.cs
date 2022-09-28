using EFCoreEncapsulate.DataContracts;

namespace EFCoreEncapsulate.Domain;

public interface IStudentRepository
{
    Task<IReadOnlyList<StudentDto>> GetAllStudentsDtoAsync();
    Task<StudentDto?> GetStudentDtoOrNullAsync(long id);
    
    Task<Student?> GetByIdOrNullAsync(long id);
    
    Task SaveAsync(Student entity);
}