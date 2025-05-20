using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Core;
using Application.Activities.Models;

namespace Application.Activities.Queries;

public class GetActivityList
{
    public class Query : IQuery<List<ActivityDto>> { }

    public class Handler(AppDbContext context) : IQueryHandler<Query, List<ActivityDto>>
    {
        public async Task<List<ActivityDto>> HandleAsync(Query query, CancellationToken cancellationToken)
        {
            var activities = await context.Activities.ToListAsync(cancellationToken);
            List<ActivityDto> activityDtos = new List<ActivityDto>();
            foreach (var activity in activities)
            {
                activityDtos.Add(ActivitiesMapper.Map(activity));
            }

            return activityDtos;
        }
    }
}