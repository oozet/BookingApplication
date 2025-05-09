using BookingApplication.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers;

[ApiController]
[Route("")]
public class RoomController : ControllerBase 
{
    [Authorize(Roles ="Admin")]
    [HttpPost("")]
    public async Task<IActionResult> Create([FromBody] CreateBookingRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles ="Admin")]
    [HttpPut("{roomId}")]
    public async Task<IActionResult> Update(Guid roomId, [FromBody] EditBookingRequest request)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles ="Admin")]
    [HttpDelete("{roomId}")]
    public async Task<IActionResult> Delete(Guid roomId)
    {
        throw new NotImplementedException();
    }

    [Authorize(Roles ="Admin")]
    [HttpGet("{roomId}")] // 
    public async Task<IActionResult> Get(Guid roomId)
    {
        throw new NotImplementedException();
    }
}

public class CreateRoomRequest : IRequest
{
    public required string Name { get; set; }
    public required int RoomNumber { get; set; }
    public required int Limit { get; set; }
    public required int Area { get; set; }
    public required double Price { get; set; }
}

public class EditRoomRequest : IRequest
{
    public required Guid Id { get; set; }
    public required string Name { get; set; }
    public required int RoomNumber { get; set; }
    public required int Limit { get; set; }
    public required int Area { get; set; }
    public required double Price { get; set; }
    public required ICollection<Booking> Bookings { get; set; }
}