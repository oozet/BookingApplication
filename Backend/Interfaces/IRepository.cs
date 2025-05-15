namespace BookingApplication.Interfaces;

public interface IRepository<T>
<<<<<<< Updated upstream
{
    public abstract Task CreateAsync(T entity);
    public Task<T?> GetByIdAsync(Guid id);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task EditAsync(T updatedEntity);
    public Task DeleteAsync(T entityToRemove);
    public Task SaveChangesAsync();
}
=======
    where T : class
{
    Task<T?> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task EditAsync(T entity);
    Task DeleteAsync(string id);
}
>>>>>>> Stashed changes
