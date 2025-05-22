using BookingApplication.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly ScheduleService scheduleService;

    public ScheduleController(ScheduleService scheduleService)
    {
        this.scheduleService = scheduleService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate
    )
    {
        try
        {
            var bookings = await scheduleService.GetScheduleAsync(startDate, endDate);
            return Ok(bookings);
        }
        catch (System.Exception)
        {
            return BadRequest("");
        }
    }
}
