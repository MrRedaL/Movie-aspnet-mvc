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

        public async Task<IEnumerable<Actor>> GetAllActors()
        {
            var allActors = await this.context.Actors.ToListAsync();
            return allActors;
        }

        public Actor GetActorById(int id)
        {
            throw new NotImplementedException();
        }

        public void AddActor(Actor actor)
        {
            this.context.Actors.Add(actor);
            this.context.SaveChanges();
        }

        public Actor UpdateActorById(int id, Actor newActor)
        {
            throw new NotImplementedException();
        }

        public void DeleteActorById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
