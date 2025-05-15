namespace BookingApplication.Interfaces;

<<<<<<< Updated upstream
public interface IService<T, TAddRequest, TEditRequest>
    where T : class
    where TAddRequest : IRequest
    where TEditRequest : IRequest
{
    public Task<T> CreateFromRequestAsync(TAddRequest request);
    public Task<T?> GetByIdAsync(Guid entityId);
=======
// Option 1
// public interface IService<T, TAddRequest, TEditRequest>
//     where T : class
//     where TAddRequest : IRequest
//     where TEditRequest : IRequest
// {
//     public Task<T> CreateFromRequestAsync(TAddRequest request);
//     public Task<T?> GetByIdAsync<TKey>(TKey entityId)
//         where TKey : notnull;
//     public Task<IEnumerable<T>> GetAllAsync();
//     public Task EditAsync(T entityToEdit);
//     public Task<T> EditFromRequestAsync(TEditRequest request);
//     public Task DeleteAsync(T entityToRemove);
//     public Task<T?> DeleteAsync<TKey>(TKey entityId)
//         where TKey : notnull;
// }

// Option 2, must declare TKey when inheriting
public interface IService<T, TAddRequest, TEditRequest, TKey>
    where T : class
    where TAddRequest : IRequest
    where TEditRequest : IRequest
    where TKey : notnull
{
    public Task<T> CreateFromRequestAsync(TAddRequest request);
    public Task<T?> GetByIdAsync(TKey entityId);
>>>>>>> Stashed changes
    public Task<IEnumerable<T>> GetAllAsync();
    public Task EditAsync(T entityToEdit);
    public Task<T> EditFromRequestAsync(TEditRequest request);
    public Task DeleteAsync(T entityToRemove);
<<<<<<< Updated upstream
    public Task<T?> DeleteAsync(Guid entityId);
=======
    public Task<T?> DeleteAsync(TKey entityId);
>>>>>>> Stashed changes
}
