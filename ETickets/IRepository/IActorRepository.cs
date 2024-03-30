using ETickets.Models;

namespace ETickets.IRepository
{
    public interface IActorRepository
    {
        void Delete(int id);

        void Update(Actor actor);

        List<Actor> ReadAll();
        Actor ReadById(int id);

        void Create(Actor actor);
    }
}
