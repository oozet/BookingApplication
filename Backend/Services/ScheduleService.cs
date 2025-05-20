using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Models.Dtos;
using BookingApplication.Repositories;
using System.Linq;

namespace BookingApplication.Services;

public class ScheduleService
{
    private readonly BookingRepository bookingRepository;

    public ScheduleService(BookingRepository bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<ScheduleResponse> GetScheduleAsync(DateTime start, DateTime end)
    {
        var bookings = await bookingRepository.GetAllAsync();
        var filteredBookings = bookings.Where(b => b.StartDate >= start && b.EndDate <= end);
        foreach (var booking in filteredBookings)
        {

        }

        return new ScheduleResponse();
    }
}

public class ScheduleResponse
{

}
