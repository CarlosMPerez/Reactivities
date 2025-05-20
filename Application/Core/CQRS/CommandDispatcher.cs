using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Core.CQRS;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public async Task DispatchAsync<TCommand>(TCommand command, CancellationToken cancellationToken) where TCommand : ICommand
    {
        var validator = serviceProvider.GetService<IValidator<TCommand>>();
        if (validator is not null)
        {
            var result = await validator.ValidateAsync(command, cancellationToken);
            if (!result.IsValid) throw new ValidationException(result.Errors);
        }

        var handler = serviceProvider.GetService<ICommandHandler<TCommand>>();
        if (handler == null)
            throw new InvalidOperationException($"No query handler registered for {typeof(TCommand).Name}");        
        await handler.HandleAsync(command, cancellationToken);
    }
}
