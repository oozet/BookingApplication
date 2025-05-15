using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers;

[ApiController]
[Route("booking")]
public class BookingController(IService<Booking, CreateBookingRequest, EditBookingRequest> bookingService) : ControllerBase
{
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> Book([FromBody] CreateBookingRequest request)
    {
        try
        {

            var booking = await bookingService.CreateFromRequestAsync(request);
            return Created(nameof(Book), new { Message = $"Created booking with Id {booking.Id}" });
        }
        catch (ArgumentException e)
        {
            return BadRequest($"The request could not be processed: {e.Message}");
        }
        catch (Exception)
        {
            return BadRequest("An unspecified error has happened");
        }
    }

    [Authorize]
    [HttpPut]
    public async Task<IActionResult> Edit([FromBody] EditBookingRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpDelete("{bookingId}")] //
    public async Task<IActionResult> Cancel(Guid bookingId)
    {
        throw new NotImplementedException();
    }
}

public class CreateBookingRequest : IRequest
{
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required Guid RoomId { get; set; }
    public required string UserId { get; set; }
    public Guid? ActivityId { get; set; }
}

public class EditBookingRequest : IRequest
{
    public required Guid Id { get; set; }
    public required DateTime StartDate { get; set; }
    public required DateTime EndDate { get; set; }
    public required float Price { get; set; }
    public required Guid RoomId { get; set; }
    public required string UserId { get; set; }
    public Guid? ActivityId { get; set; }
}

