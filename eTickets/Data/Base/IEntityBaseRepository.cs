using eTickets.Models;

namespace eTickets.Data.Base
{
    public interface IEntityBaseRepository<T> where T : class, IEntityBase, new()
    {
        Task<IEnumerable<T>> GetAllActorsAsync();
        Task<T> GetActorByIdAsync(int id);
        Task AddActorAsync(T entity);
        Task<T> UpdateActorByIdAsync(int id, T entity);
        Task DeleteActorByIdAsync(int id);
    }
}
