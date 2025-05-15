using BookingApplication.Data;
using BookingApplication.Models;
using Microsoft.EntityFrameworkCore;

public class BookingRepository : IRepository<Booking>
{
    private readonly BookingAppContext _context;

    public BookingRepository(BookingAppContext context)
    {
        _context = context;
    }

    public async Task<Booking?> GetByIdAsync(string id)
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .Include(b => b.Activity)
            .FirstOrDefaultAsync(b => b.Id.ToString() == id);
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .Include(b => b.Activity)
            .ToListAsync();
    }

    public async Task AddAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Entry(booking).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(Booking booking)
    {
        _context.Bookings.Remove(booking);
        await _context.SaveChangesAsync();
    }
  public async Task<IEnumerable<Booking>> GetByTimeSpanAsync(DateTime start, DateTime end)
    {
        return await _context.Bookings
            .Where(b => b.StartDate >= start && b.EndDate <= end)
            .Include(b => b.User)
            .Include(b => b.Room)
            .Include(b => b.Activity)
            .ToListAsync();
    }

    public async Task<IEnumerable<Booking>> GetByUserIdAsync(string userId)
    {
        return await _context.Bookings
            .Where(b => b.UserId == userId)
            .Include(b => b.Room)
            .Include(b => b.Activity)
            .ToListAsync();
    }
}