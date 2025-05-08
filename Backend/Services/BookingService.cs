using BookingApplication.Controllers;
using BookingApplication.Data;
using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Repositories;

namespace BookingApplication.Services;

public class BookingService : EfService<Booking, CreateBookingRequest, EditBookingRequest>
{
    public BookingService(IRepository<Booking> repository) : base(repository) {}

    public override async Task<Booking> CreateFromRequestAsync(CreateBookingRequest request)
    {
        if(request.StartDate < DateTime.Now || request.EndDate < DateTime.Now)
        {
            throw new Exception("Booking dates can't be in the past");
        }
        if(request.RoomId == Guid.Empty)
        {
            throw new Exception("A room must be linked to the booking");
        }
        if(string.IsNullOrWhiteSpace(request.UserId))
        {
            throw new Exception("A user must be linked to the booking");
        }
        if(request.Price < 0)
        {
            throw new Exception("Price can't be negative");
        }

        /* 
        Should booking service have a dependency to roomRepository or is the price calculation done elsewhere?

        var room = roomRepository.GetByIdAsync(request.RoomId);
        var price = room.Price * (request.EndDate - request.StartDate).Days;
        */

        var booking = new Booking
        {
            Id = new Guid(), // ?
            StartDate = request.StartDate,
            EndDate = request.EndDate,
            Price = request.Price,
            RoomId = request.RoomId,
            UserId = request.UserId,
            ActivityId = request.ActivityId,
        };

        await repository.CreateAsync(booking);
        return booking;
    }

    public override async Task<Booking> EditFromRequestAsync(EditBookingRequest request)
    {
        throw new NotImplementedException();
    }

    public async Task<List<Booking>> GetByTimeSpanAsync(DateTime start, DateTime end)
    {
        throw new NotImplementedException();
    }
}