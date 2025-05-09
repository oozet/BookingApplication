using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers;

[ApiController]
[Route("")]
public class BookingController : ControllerBase 
{
    [Authorize]
    [HttpPost("")]
    public async Task<IActionResult> Book([FromBody] CreateBookingRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize]
    [HttpPut("{bookingId}")]
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
    public required float Price { get; set; }
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