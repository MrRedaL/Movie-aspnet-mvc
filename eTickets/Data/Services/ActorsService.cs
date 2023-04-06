using eTickets.Models;
using Microsoft.EntityFrameworkCore;

namespace eTickets.Data.Services
{
    public class ActorsService : IActorsService
    {
        private readonly AppDbContext context;

        public ActorsService(AppDbContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Actor>> GetAllActorsAsync()
        {
            var allActors = await this.context.Actors.ToListAsync();
            return allActors;
        }

        public async Task<Actor> GetActorByIdAsync(int id)
        {
            var actor = await this.context.Actors.FirstOrDefaultAsync(x => x.Id == id);
            return actor;
        }

        public async Task AddActorAsync(Actor actor)
        {
            await this.context.Actors.AddAsync(actor);
            await this.context.SaveChangesAsync();
        }

        public async Task<Actor> UpdateActorByIdAsync(int id, Actor newActor)
        {
            this.context.Update(newActor);
            await this.context.SaveChangesAsync();
            return newActor;
        }

        public void DeleteActorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
