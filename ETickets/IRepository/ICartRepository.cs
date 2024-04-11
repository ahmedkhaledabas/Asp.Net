using ETickets.Models;

namespace ETickets.IRepository
{
    public interface ICartRepository
    {

        Movie GetMovie(int id);

        ApplicationUser GetUser(string userName);
    }
}
