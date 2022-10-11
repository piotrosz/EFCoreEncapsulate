using CSharpFunctionalExtensions;
using EFCoreEncapsulate.SharedKernel;
using Newtonsoft.Json;

namespace EFCoreEncapsulate.Domain.Decorators;

public sealed class AuditLoggingDecorator<TCommand> : ICommandHandler<TCommand>
    where TCommand : ICommand
{
    private readonly ICommandHandler<TCommand> _handler;

    public AuditLoggingDecorator(ICommandHandler<TCommand> handler)
    {
        _handler = handler;
    }

    public async Task<Result> HandleAsync(TCommand command)
    {
        string commandJson = JsonConvert.SerializeObject(command);

        // Use proper logging here
        Console.WriteLine($"Command of type {command.GetType().Name}: {commandJson}");

        return await _handler.HandleAsync(command);
    }
}
