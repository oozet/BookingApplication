using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("")]
public class ScheduleController : ControllerBase
{
    [HttpGet("{}")] 
    public async Task<IActionResult> GetRooms([FromQuery] DateTime startDate, [FromQuery] DateTime endDate)
    {
        throw new NotImplementedException();
    }
}