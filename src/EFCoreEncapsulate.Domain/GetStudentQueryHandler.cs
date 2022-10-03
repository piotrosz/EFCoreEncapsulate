using CSharpFunctionalExtensions;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class GetStudentQueryHandler : IQueryHandler<GetStudentQuery, Result<StudentDto>>
{
    private readonly IStudentRepository _studentRepository;

    public GetStudentQueryHandler(IStudentRepository studentRepository)
    {
        _studentRepository = studentRepository;
    }

    public async Task<Result<StudentDto>> HandleAsync(GetStudentQuery query)
    {
        StudentDto? student = await _studentRepository.GetStudentDtoOrNullAsync(query.Id);

        if (student is null)
        {
            return Result.Failure<StudentDto>("Student not found");
        }

        return Result.Success(student);
    }
}