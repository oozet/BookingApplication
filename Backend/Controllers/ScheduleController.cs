using BookingApplication.Exceptions;
using BookingApplication.Services;
using BookingApplication.Models.Dtos;
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

    [HttpPost]
    public async Task<IActionResult> GetSchedule([FromBody] ScheduleRequest request)
    {
        try
        {
            // DateTime startDate = DateTime.Parse(request.startDate);
            // DateTime endDate = DateTime.Parse(request.endDate);
            var bookings = await scheduleService.GetScheduleAsync(request.startDate, request.endDate);
            return Ok(bookings);
        }
        catch (DateErrorException ex)
        {
            // Logger not implemented
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Unable to get bookings");
        }
        catch
        {
            return BadRequest("");
        }
    }


    [HttpGet]
    public async Task<IActionResult> GetScheduleQuery([FromQuery] int year, [FromQuery] int week)
    {
        try
        {
            if (1 > week || week > 53) return BadRequest("Invalid week number");

            var (startDate, endDate) = WeekHelper.GetWeekStartAndEnd(year, week);

            // DateTime startDate = DateTime.Parse(request.startDate);
            // DateTime endDate = DateTime.Parse(request.endDate);
            var bookings = await scheduleService.GetScheduleAsync(startDate, endDate);
            return Ok(bookings);
        }
        catch (DateErrorException ex)
        {
            // Logger not implemented
            Console.WriteLine(ex.Message);
            return StatusCode(500, "Unable to get bookings");
        }
        catch
        {
            return BadRequest("");
        }
    }

    // [HttpGet]
    // public async Task<IActionResult> GetSchedule(
    //     [FromQuery] DateTime? startDate,
    //     [FromQuery] DateTime? endDate
    // )
    // {
    //     try
    //     {
    //         if (startDate == null || endDate == null)
    //         {
    //             (startDate, endDate) = DateTime.Today.GetCurrentWeek();
    //         }

    //         var bookings = await scheduleService.GetScheduleAsync(startDate ?? throw new DateErrorException("Error while converting a nullable DateTime startDate to non nullable"),
    //         endDate ?? throw new DateErrorException("Error while converting a nullable DateTime endDate to non nullable"));
    //         return Ok(bookings);
    //     }
    //     catch (DateErrorException ex)
    //     {
    //         // Logger not implemented
    //         Console.WriteLine(ex.Message);
    //         return StatusCode(500, "Unable to get bookings");
    //     }
    //     catch
    //     {
    //         return BadRequest("");
    //     }
    // }
}

