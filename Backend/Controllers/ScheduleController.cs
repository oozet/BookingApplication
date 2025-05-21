using BookingApplication.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("schedule")]
public class ScheduleController : ControllerBase
{
    private readonly RoomService roomService;

    public ScheduleController(RoomService roomService)
    {
        this.roomService = roomService;
    }

    [HttpGet]
    public async Task<IActionResult> GetRooms(
        [FromQuery] DateTime startDate,
        [FromQuery] DateTime endDate
    )
    {
        try
        {
            // var rooms = roomService.GetRoomsFromSpan(startDate, endDate);
            // return Ok(rooms);

            return Ok();
        }
        catch (System.Exception)
        {
            return BadRequest("");
        }
    }
}
