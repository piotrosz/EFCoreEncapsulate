using CSharpFunctionalExtensions;

namespace EFCoreEncapsulate.Domain;

public interface ICommandHandler<TCommand>
    where TCommand : ICommand
{
    Task<Result> HandleAsync(TCommand command);
}