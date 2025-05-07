using BookingApplication.Data;
using BookingApplication.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BookingApplication.Repositories;

public class UserRepository : EfRepository<User> {

    public UserRepository(AppDbContext context) : base (context)
    {
        
    }
}