using eTickets.Models;

namespace eTickets.Data.Services
{
    public interface IActorsService
    {
        IEnumerable<Actor> GetAllActors();
        Actor GetActorById(int id);
        void AddActor(Actor actor);
        Actor UpdateActorById(int id, Actor newActor);
        void DeleteActorById(int id);
    }
}
