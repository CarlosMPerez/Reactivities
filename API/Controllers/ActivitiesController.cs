using Application.Activities.Commands;
using Application.Activities.Queries;
using Application.Activities.Models;
using Microsoft.AspNetCore.Mvc;
using Application.Core;
using Application.Core.CQRS;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ActivitiesController : ControllerBase
{
    private readonly ICommandDispatcher _commandDispatcher;
    private readonly IQueryDispatcher _queryDispatcher;

    public ActivitiesController(ICommandDispatcher commandDispatcher, IQueryDispatcher queryDispatcher)
    {
        _commandDispatcher = commandDispatcher;
        _queryDispatcher = queryDispatcher;
    }

    [HttpGet]
    public async Task<ActionResult<List<ActivityDto>>> GetActivities(CancellationToken cancellationToken)
    {
        var query = new GetActivityList.Query { };
        var result = await _queryDispatcher.DispatchAsync<GetActivityList.Query, List<ActivityDto>>(query, cancellationToken);
        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDto>> GetActivity(string id, CancellationToken cancellationToken)
    {
        try
        {
            var query = new GetActivityDetails.Query { Id = id };
            var result = await _queryDispatcher.DispatchAsync<GetActivityDetails.Query, ActivityDto>(query, cancellationToken);
            return Ok(result);
        }
        catch (KeyNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    public async Task<ActionResult> CreateActivity(CreateActivityDto dto, CancellationToken cancellationToken)
    {
        await _commandDispatcher.DispatchAsync(new CreateActivity.Command { Model = dto }, cancellationToken);
        return Ok();
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(ActivityDto activity, CancellationToken cancellationToken)
    {
        await _commandDispatcher.DispatchAsync(new EditActivity.Command { ActivityDto = activity }, cancellationToken);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id, CancellationToken cancellationToken)
    {
        await _commandDispatcher.DispatchAsync(new DeleteActivity.Command { Id = id }, cancellationToken);
        return Ok();
    }
}
