using ETickets.Models;

namespace ETickets.IRepository
{
    public interface ITicketRepository
    {
        void Delete(int id);

        void Update(Ticket ticket);

        List<Ticket> ReadAll();
        Ticket ReadById(int id);

        void Create(Ticket ticket);
    }
}
