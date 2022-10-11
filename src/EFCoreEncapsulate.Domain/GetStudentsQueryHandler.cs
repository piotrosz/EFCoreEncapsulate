using CSharpFunctionalExtensions;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class GetStudentsQueryHandler : IQueryHandler<GetStudentsQuery, Result<IReadOnlyList<StudentDto>>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentsQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Result<IReadOnlyList<StudentDto>>> HandleAsync(GetStudentsQuery query)
    {
        var students = await _studentRepository.GetAllStudentsDtoAsync();
        return Result.Success(students);
    }
}