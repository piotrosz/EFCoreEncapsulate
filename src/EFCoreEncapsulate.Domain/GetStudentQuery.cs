using CSharpFunctionalExtensions;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class GetStudentQuery : IQuery<Result<StudentDto>>
{
    public GetStudentQuery(long id)
    {
        Id = id;
    }

    public long Id { get; }
}