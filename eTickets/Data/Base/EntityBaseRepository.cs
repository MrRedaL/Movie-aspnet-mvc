using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace eTickets.Data.Base
{
    public class EntityBaseRepository<T>: IEntityBaseRepository<T> where T: class, IEntityBase, new()
    {
        private readonly AppDbContext context;
        public EntityBaseRepository(AppDbContext context)
        {
            this.context = context;
        }
                
        public async Task AddAsync(T entity)
        {
            await this.context.Set<T>().AddAsync(entity);
            await this.context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var entity = await this.context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
            EntityEntry entityEntry = this.context.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await this.context.SaveChangesAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await this.context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await this.context.Set<T>().ToListAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = this.context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

        public async Task UpdateByIdAsync(int id, T entity)
        {
            EntityEntry entityEntry = this.context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await this.context.SaveChangesAsync();
        }
    }
}
