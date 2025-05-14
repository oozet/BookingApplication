namespace BookingApplication.Interfaces;


  public interface IRepository<T> where T : class
{
    Task<T> GetByIdAsync(Guid id);
    Task<IEnumerable<T>> GetAllAsync();
    Task CreateAsync(T entity);
    Task EditAsync(T entity);
    Task DeleteAsync(string id);
}

