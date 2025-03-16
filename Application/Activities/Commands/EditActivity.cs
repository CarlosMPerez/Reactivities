using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Core;
using Application.Activities.Models;

namespace Application.Activities.Commands;

public class EditActivity
{
    public class Command : IRequest
    {
        public required ActivityDto ActivityDto { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command>
    {
        public async Task Handle(Command request, CancellationToken cancellationToken)
        {
            var activity = await context.Activities
                                .FindAsync([request.ActivityDto.Id], cancellationToken)
                                ?? throw new Exception("Cannot find activity");
            context.Entry(activity).State = EntityState.Detached;

            activity = ActivitiesMapper.Map(request.ActivityDto);

            context.Activities.Update(activity);
            await context.SaveChangesAsync(cancellationToken);
        }
    }
}
