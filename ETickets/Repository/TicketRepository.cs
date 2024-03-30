using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class TicketRepository : ITicketRepository
    {
        ETicketsDbContext context;

        public TicketRepository(ETicketsDbContext eTicketsDbContext)
        {
            context = eTicketsDbContext;
        }
        void ITicketRepository.Create(Ticket ticket)
        {
            context.Tickets.Add(ticket);
            context.SaveChanges();
        }

        void ITicketRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<Ticket> ITicketRepository.ReadAll()
        {
            return context.Tickets.Include(t => t.Movie).ThenInclude(m => m.Cinema).ToList();
        }

        Ticket ITicketRepository.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void ITicketRepository.Update(Ticket ticket)
        {
            throw new NotImplementedException();
        }
    }
}
