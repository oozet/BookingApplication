using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookingApplication.Controllers;

[ApiController]
[Route("booking")]
public class BookingController : ControllerBase
{
    [Authorize]
    [HttpPost]
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

public class CreateBookingRequest : IRequest { }

public class EditBookingRequest : IRequest { }
