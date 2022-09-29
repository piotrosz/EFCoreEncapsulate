using CSharpFunctionalExtensions;
using EFCoreEncapsulate.SharedKernel;

namespace EFCoreEncapsulate.Infrastructure;

public sealed class Messages
{
    private readonly IServiceProvider _provider;

    public Messages(IServiceProvider provider)
    {
        _provider = provider;
    }

    public async Task<Result> DispatchAsync(ICommand command)
    {
        Type type = typeof(ICommandHandler<>);
        Type[] typeArgs = { command.GetType() };
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetService(handlerType);
        Result result = await handler.HandleAsync((dynamic)command);

        return result;
    }

    public async Task<T> DispatchAsync<T>(IQuery<T> query)
    {
        Type type = typeof(IQueryHandler<,>);
        Type[] typeArgs = { query.GetType(), typeof(T) };
        Type handlerType = type.MakeGenericType(typeArgs);

        dynamic handler = _provider.GetService(handlerType);
        T result = await handler.HandleAsync((dynamic)query);

        return result;
    }
}