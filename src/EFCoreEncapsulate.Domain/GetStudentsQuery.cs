using CSharpFunctionalExtensions;
using EFCoreEncapsulate.DataContracts;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Domain;

public class GetStudentsQuery : IQuery<Result<IReadOnlyList<StudentDto>>>
{
}