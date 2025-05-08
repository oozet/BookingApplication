using BookingApplication.Data;
using BookingApplication.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BookingApplication.Repositories;

public class EfRepository<T> : IRepository<T>
    where T : class
{
    protected readonly BookingAppContext context;

    public EfRepository(BookingAppContext context)
    {
        this.context = context;
    }

    public async Task CreateAsync(T toCreate)
    {
        await context.Set<T>().AddAsync(toCreate);
        await context.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entityToRemove)
    {
        context.Set<T>().Remove(entityToRemove);
        await context.SaveChangesAsync();
    }

    public async Task<T?> GetByIdAsync(Guid id)
    {
        var item = await context.Set<T>().FindAsync(id);
        return item;
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await context.Set<T>().ToListAsync();
    }

    public async Task EditAsync(T updatedEntity)
    {
        context.Set<T>().Update(updatedEntity);
        await context.SaveChangesAsync();
    }
}
