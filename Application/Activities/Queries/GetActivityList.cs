using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistence;
using Application.Core;
using Application.Activities.Models;

namespace Application.Activities.Queries;

public class GetActivityList
{
    public class Query : IRequest<List<ActivityDto>> { }

    public class Handler(AppDbContext context) : IRequestHandler<Query, List<ActivityDto>>
    {
        public async Task<List<ActivityDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var activities = await context.Activities.ToListAsync(cancellationToken);
            List<ActivityDto> activityDtos = new List<ActivityDto>();
            foreach (var activity in activities)
            {
                activityDtos.Add(ReactivitiesMapper.Map(activity));
            }

            return activityDtos;
        }
    }
}