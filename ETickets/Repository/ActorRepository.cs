using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;

namespace ETickets.Repository
{
    public class ActorRepository : IActorRepository
    {
        ETicketsDbContext context;

        public ActorRepository (ETicketsDbContext eTicketsDbContext)
        {
            this.context = eTicketsDbContext;
        }
        void IActorRepository.Create(Actor actor)
        {
            throw new NotImplementedException();
        }

        void IActorRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<Actor> IActorRepository.ReadAll()
        {
            throw new NotImplementedException();
        }

        Actor IActorRepository.ReadById(int id)
        {
            var actor =  context.Actors.Find(id);
            if(actor != null)
            {
                return actor;
            }
            throw new NullReferenceException();
        }

        void IActorRepository.Update(Actor actor)
        {
            throw new NotImplementedException();
        }
    }
}
