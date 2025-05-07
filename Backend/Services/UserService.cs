using Backend_ind.Services;
using BookingApplication.Controllers;
using BookingApplication.Interfaces;
using BookingApplication.Models;

public class UserService : EfService<User, RegisterRequest, EditUserRequest>
{
    public UserService(IRepository<User> repository) : base(repository) {}

    public override Task<User> CreateFromRequestAsync(RegisterRequest request)
    {
        throw new NotImplementedException();
    }

    public override Task<User> EditFromRequestAsync(EditUserRequest request)
    {
        throw new NotImplementedException();
    }
}