using System;
using System.Runtime.InteropServices;
using Domain;
using MediatR;
using Persistence;

namespace Application.Activities.Queries;

public class GetActivityDetails
{
    public class Query : IRequest<ActivityDto>
    {
        public required string Id { get; set; }
    }

    public class Handler(AppDbContext context) : IRequestHandler<Query, ActivityDto>
    {
        public async Task<ActivityDto> Handle(Query request, CancellationToken cancellationToken)
        {
            var actv = await context.Activities
                        .FindAsync([request.Id], cancellationToken);
            
            if (actv == null) throw new Exception("Activity not found");

            return MapperlyMapper.Map(actv);
        }
    }
}
