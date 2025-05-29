using BookingApplication.Interfaces;
using BookingApplication.Models;
using BookingApplication.Models.Dtos;
using BookingApplication.Repositories;
using System.Linq;

namespace BookingApplication.Services;

public class ScheduleService
{
    private readonly IRepository<Booking> bookingRepository;

    public ScheduleService(IRepository<Booking> bookingRepository)
    {
        this.bookingRepository = bookingRepository;
    }

    public async Task<List<BookingResponse>> GetScheduleAsync(DateTime start, DateTime end)
    {
        var bookings = await bookingRepository.GetAllAsync();
        var filteredBookings = bookings.Where(b => b.StartDate >= start && b.EndDate <= end).OrderBy(b => b.StartDate).ToList();
        var schedule = new List<BookingResponse>();
        foreach (var booking in filteredBookings)
        {
            schedule.Add(BookingResponse.FromModel(booking));
        }
        return schedule;
    }
}