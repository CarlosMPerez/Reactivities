using MediatR;
using Persistence;
using Application.Core;
using Application.Activities.Models;
using FluentValidation;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required CreateActivityDto Model { get; set; }
    }

    public class Handler(AppDbContext context, IValidator<Command> validator) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            await validator.ValidateAndThrowAsync(request, cancellationToken);
            var newActivity = ActivitiesMapper.Map(request.Model);
            context.Activities.Add(newActivity);
            await context.SaveChangesAsync(cancellationToken);
            return newActivity.Id!;
        }
    }
}
