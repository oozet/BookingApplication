namespace BookingApplication.Interfaces;

public interface IService<T, TAddRequest, TEditRequest>
    where T : class
    where TAddRequest : IRequest
    where TEditRequest : IRequest
{
    public Task<T> CreateFromRequestAsync(TAddRequest request);
    public Task<T?> GetByIdAsync(Guid entityId);
    public Task<IEnumerable<T>> GetAllAsync();
    public Task EditAsync(T entityToEdit);
    public Task<T> EditFromRequestAsync(TEditRequest request);
    public Task DeleteAsync(T entityToRemove);
    public Task DeleteAsync(Guid entityId);
}
