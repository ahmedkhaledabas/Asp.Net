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

        public ApplicationUser GetUser(string id)
        {
            var user = context.Users.Find(id);
            if(user != null)
            {
                return user;
            }
            else throw new NullReferenceException();
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

        List<Movie> ICartRepository.ReadAll(ApplicationUser user)
        {
            var cart = context.Carts.Include(c=>c.Movies).FirstOrDefault(c=>c.ApplicationUserId == user.Id);
            return cart.Movies;
        } 

        //Cart ICartRepository.ReadById(int id) {

        //    var cart = context.Carts.Find(id);
        //    if(cart != null)
        //    {
        //        return cart;
        //    }
        //    throw new NullReferenceException();
        //}


        //Cart ICartRepository.ReadById(string id)
        //{

        //    var carts = context.Users.Find(id).Carts;
        //    foreach (var c in carts)
        //    {
        //        return c;
        //    }
        //    throw new NullReferenceException();
        //}


        void ICartRepository.Update(Cart cart)
        {
            throw new NotImplementedException();
        }

        public void Recet()
        {
            context.Database.ExecuteSql($"truncate table Carts");
            context.SaveChanges();
        }

        public Cart CheckCart(ApplicationUser user)
        {
            var finduser = context.Users.Find(user.Id);
            return finduser.Cart;
        }

        
    }
}
