using Backend_ind.Services;
using BookingApplication.Controllers;
using BookingApplication.Interfaces;
using BookingApplication.Models;

public class ActivityService : EfService<Activity, CreateActivityRequest, EditActivityRequest>
{
    public ActivityService(IRepository<Activity> repository) : base(repository) {}

    public override Task<Activity> CreateFromRequestAsync(CreateActivityRequest request)
    {
        throw new NotImplementedException();
    }

    public override Task<Activity> EditFromRequestAsync(EditActivityRequest request)
    {
        throw new NotImplementedException();
    }
}