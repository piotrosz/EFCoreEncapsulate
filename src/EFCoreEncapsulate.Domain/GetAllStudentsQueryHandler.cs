using CSharpFunctionalExtensions;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class GetAllStudentsQueryHandler : IQueryHandler<GetAllStudentsQuery, Result<IReadOnlyList<StudentDto>>>
{
    private readonly IStudentRepository _studentRepository;

    public GetAllStudentsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Result<IReadOnlyList<StudentDto>>> HandleAsync(GetAllStudentsQuery query)
    {
        var students = await _studentRepository.GetAllStudentsDtoAsync();
        return Result.Success(students);
    }
}