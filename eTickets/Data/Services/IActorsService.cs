using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        Task<IEnumerable<Actor>> GetAllActorsAsync();
        Task<Actor> GetActorByIdAsync(int id);
        Task AddActorAsync(Actor actor);
        Task<Actor> UpdateActorByIdAsync(int id, Actor newActor);
        Task DeleteActorByIdAsync(int id);
    }
}
