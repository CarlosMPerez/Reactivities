using Application.Core;
using Persistence;

namespace Application.Activities.Commands;

public class DeleteActivity
{
    public class Command : ICommand
    {
        public required string Id { get; set;}
    }

    public class Handler(AppDbContext context) : ICommandHandler<Command>
    {
        public async Task HandleAsync(Command command, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                                .FindAsync([command.Id], cancellationToken) 
                                ?? throw new Exception("Cannot find activity");
            context.Remove(activity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
