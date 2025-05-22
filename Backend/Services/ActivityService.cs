using BookingApplication.Controllers;
using BookingApplication.Interfaces;
using BookingApplication.Models;

namespace BookingApplication.Services;

public class ActivityService : EfService<Activity, CreateActivityRequest, EditActivityRequest>
{
    public ActivityService(IRepository<Activity> repository) : base(repository) {}

    public override async Task<Activity> CreateFromRequestAsync(CreateActivityRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.Name))
        {
            throw new Exception("Activity must have a name");
        }

        var activity = new Activity
        {
            Id = Guid.NewGuid(),
            Name = request.Name,
            Description = request.Description,
        };

        await repository.CreateAsync(activity);
        return activity;
    }

    public override async Task<Activity> EditFromRequestAsync(EditActivityRequest request)
    {
        if(string.IsNullOrWhiteSpace(request.Name))
        {
            throw new Exception("Activity must have a name");
        }

        var activity = new Activity 
        {
            Id = request.Id,
            Name = request.Name,
            Description = request.Description,
        };

        await repository.EditAsync(activity);
        return activity;
    }
}