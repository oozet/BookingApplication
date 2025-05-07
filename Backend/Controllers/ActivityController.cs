using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("")]
public class ActivityController : ControllerBase
{
    [Authorize(Roles ="Admin")]
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] CreateActivityRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles ="Admin")]
    [HttpPut("{activityId}")]
    public async Task<IActionResult> Update(Guid activityId, [FromBody] EditActivityRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles ="Admin")]
    [HttpDelete("{activityId}")]
    public async Task<IActionResult> Delete(Guid activityId)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{activityId}")] // 
    public async Task<IActionResult> Get(Guid activityId)
    {
        throw new NotImplementedException();
    }
}

public class CreateActivityRequest : IRequest
{

}

public class EditActivityRequest : IRequest
{
    
}