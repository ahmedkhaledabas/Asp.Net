using ETickets.Models;
using ETickets.ViewModels;

namespace ETickets.IRepository
{
    public interface ICartRepository
    {
        void Delete(int id);

        void Update(Cart cart);

        List<Cart> ReadAll();

        Cart ReadById(int id);

        void Create(Cart cart);

        Movie GetMovie(int id);

        void PlusQuntity(Cart cart);
        void MinusQuntity(Cart cart);

        void Recet();
    }
}
