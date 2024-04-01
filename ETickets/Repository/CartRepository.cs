using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class CartRepository : ICartRepository
    {
        ETicketsDbContext context;

        public CartRepository(ETicketsDbContext eTicketsDbContext)
        {
            this.context = eTicketsDbContext;   
        }

        void ICartRepository.Create(Cart cart)
        {
            context.Carts.Add(cart);
            context.SaveChanges();
        }

        void ICartRepository.Delete(int id)
        {
            var cart = context.Carts.Find(id);
            if (cart != null)
            {
                context.Carts.Remove(cart);
                context.SaveChanges();
            }
        }

        Movie ICartRepository.GetMovie(int id)
        {
            var movie = context.Movies.Find(id);
            if (movie != null)
            {
                return movie;
            }
            else throw new NullReferenceException();
        }

        void ICartRepository.PlusQuntity(Cart cart)
        {
            cart.Quantity++;
            context.SaveChanges();
        }

        void ICartRepository.MinusQuntity(Cart cart)
        {
            cart.Quantity--;
            context.SaveChanges();
        }

        List<Cart> ICartRepository.ReadAll()=> context.Carts.Include(c=>c.Movie).ThenInclude(m=>m.Cinema).ToList();

        Cart ICartRepository.ReadById(int id) {

            var cart = context.Carts.Find(id);
            if(cart != null)
            {
                return cart;
            }
            throw new NullReferenceException();
        }

        void ICartRepository.Update(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void Recet()
        {
            context.Database.ExecuteSql($"truncate table Carts");
            context.SaveChanges();
        }

    }
}
