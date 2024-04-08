using ETickets.Models;
using ETickets.ViewModels;

namespace ETickets.IRepository
{
    public interface ICartRepository
    {
        ApplicationUser GetUser(string id);
        void Delete(int id);

        void Update(Cart cart);


        Cart CheckCart(ApplicationUser user);
        List<Movie> ReadAll(ApplicationUser user);

        //Cart ReadById(string id);

        void Create(Cart cart);

        Movie GetMovie(int id);

        void PlusQuntity(Cart cart);
        void MinusQuntity(Cart cart);

        void Recet();
    }
}
