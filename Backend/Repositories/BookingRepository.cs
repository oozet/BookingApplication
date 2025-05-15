public class BookingRepository : IRepository<Booking>
{
<<<<<<< Updated upstream
    private readonly AppDbContext _context;

    public BookingRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<Booking> GetByIdAsync(string id)
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .Include(b => b.Activity)
            .FirstOrDefaultAsync(b => b.Id == id);
    }

    public async Task<IEnumerable<Booking>> GetAllAsync()
    {
        return await _context.Bookings
            .Include(b => b.User)
            .Include(b => b.Room)
            .Include(b => b.Activity)
            .ToListAsync();
    }
=======
    public class BookingRepository : EfRepository<Booking>
    {
        public BookingRepository(BookingAppContext context)
            : base(context) { }

        public override async Task<Booking?> GetByIdAsync(Guid id)
        {
            return await _context
                .Bookings.Include(b => b.User)
                .Include(b => b.Room)
                .Include(b => b.Activity)
                .FirstOrDefaultAsync(b => b.Id == id);
        }

        public override async Task<IEnumerable<Booking>> GetAllAsync()
        {
            return await _context
                .Bookings.Include(b => b.User)
                .Include(b => b.Room)
                .Include(b => b.Activity)
                .ToListAsync();
        }
>>>>>>> Stashed changes

    public async Task<Booking> AddAsync(Booking booking)
    {
        _context.Bookings.Add(booking);
        await _context.SaveChangesAsync();
        return booking;
    }

    public async Task UpdateAsync(Booking booking)
    {
        _context.Entry(booking).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(string id)
    {
        var booking = await _context.Bookings.FindAsync(id);
        if (booking != null)
        {
<<<<<<< Updated upstream
            _context.Bookings.Remove(booking);
            await _context.SaveChangesAsync();
        }
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
=======
            return await _context
                .Bookings.Where(b => b.UserId == userId.ToString())
                .Include(b => b.Room)
                .Include(b => b.Activity)
                .ToListAsync();
        }
    }
}
>>>>>>> Stashed changes
