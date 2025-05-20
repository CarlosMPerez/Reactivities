using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Core;
using Application.Activities.Models;

namespace Application.Activities.Commands;

public class EditActivity
{
    public class Command : ICommand
    {
        public required ActivityDto ActivityDto { get; set; }
    }

    public class Handler(AppDbContext context) : ICommandHandler<Command>
    {
        public async Task HandleAsync(Command command, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                                .FindAsync([command.ActivityDto.Id], cancellationToken)
                                ?? throw new Exception("Cannot find activity");
            context.Entry(activity).State = EntityState.Detached;

            activity = command.ActivityDto.ToEntity();

            context.Activities.Update(activity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
