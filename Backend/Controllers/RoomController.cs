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

}

public class EditRoomRequest : IRequest
{
    
}