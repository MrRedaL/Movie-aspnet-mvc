namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T>: IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        public Task AddActorAsync(T entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteActorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetActorByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> GetAllActorsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<T> UpdateActorByIdAsync(int id, T entity)
        {
            throw new NotImplementedException();
        }
    }
}
