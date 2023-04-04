using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task AddActorAsync(Actor actor);
        Actor UpdateActorById(int id, Actor newActor);
        void DeleteActorById(int id);
    }
}
