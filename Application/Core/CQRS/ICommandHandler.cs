using System;

namespace Application.Core;

public interface ICommandHandler<TCommand> where TCommand: ICommand
{
    Task HandleAsync(TCommand command, CancellationToken cancellationToken);
}
