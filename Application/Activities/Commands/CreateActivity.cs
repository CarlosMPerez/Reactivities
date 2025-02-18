using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Commands;

public class CreateActivity
{
    public class Command : IRequest<string>
    {
        public required ActivityDto ActivityDto { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Command, string>
    {
        public async Task<string> Handle(Command request, CancellationToken cancellationToken)
        {
            context.Activities.Add(MapperlyMapper.Map(request.ActivityDto));
            await context.SaveChangesAsync(cancellationToken);
            return request.ActivityDto.Id!;
        }
    }
}
