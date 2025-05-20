using Persistence;
using Application.Core;
using Application.Activities.Models;
using FluentValidation;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : ICommand
    {
        public required CreateActivityDto Model { get; set; }
    }

    public class Handler(AppDbContext context) : ICommandHandler<Command>
    {
        public async Task HandleAsync(Command command, CancellationToken cancellationToken)
        {
            var newActivity = ActivitiesMapper.Map(command.Model);
            context.Activities.Add(newActivity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
