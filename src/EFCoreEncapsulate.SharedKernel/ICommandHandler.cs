using CSharpFunctionalExtensions;

namespace EFCoreEncapsulate.SharedKernel;

public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Task<Result> HandleAsync(TCommand command);
}