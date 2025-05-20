using Persistence;
using Application.Core;
using Application.Activities.Models;

namespace Application.Activities.Queries;

public class GetActivityDetails
{
    public class Query : IQuery<ActivityDto>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IQueryHandler<Query, ActivityDto>
    {
        public async Task<ActivityDto> HandleAsync(Query query, CancellationToken cancellationToken)
        {
            var actv = await context.Activities
                        .FindAsync([query.Id], cancellationToken);

            if (actv == null) throw new Exception("Activity not found");

            return ActivitiesMapper.Map(actv);
        }
    }
}
