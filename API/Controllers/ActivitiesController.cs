using Application.Activities.Commands;
using Application.Activities.Queries;
using Application;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

public class ActivitiesController() : BaseApiController
{
    [HttpGet]
    public async Task<ActionResult<List<ActivityDto>>> GetActivities( )
    {
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<ActivityDto>> GetActivity(string id)
    {
        return await Mediator.Send(new GetActivityDetails.Query{Id = id});
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(ActivityDto activity)
    {
        return await Mediator.Send(new CreateActivity.Command{ActivityDto = activity});
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(ActivityDto activity)
    {
        await Mediator.Send(new EditActivity.Command{ActivityDto = activity});
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.Command{Id = id});
        return Ok();
    }
}
