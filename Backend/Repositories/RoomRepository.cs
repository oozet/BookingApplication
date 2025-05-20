using BookingApplication.Data;
using BookingApplication.Models;
using BookingApplication.Repositories;
using Microsoft.EntityFrameworkCore;

public class RoomRepository : EfRepository<Room>
    {
        public RoomRepository(BookingAppContext context) : base(context)
        {
        }

        //Room specific method
        public async Task<IEnumerable<Room>> GetAvailableRoomsAsync(DateTime start, DateTime end)
        {
            var bookedRoomIds = await _context.Bookings
                .Where(b => (b.StartDate <= end && b.EndDate >= start))
                .Select(b => b.RoomId)
                .Distinct()
                .ToListAsync();

            return await _context.Rooms
                .Where(r => !bookedRoomIds.Contains(r.Id))
                .ToListAsync();
        }
    }