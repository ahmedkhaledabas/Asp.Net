using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class CartRepository : ICartRepository
    {
        private readonly ETicketsDbContext context;

        public CartRepository(ETicketsDbContext context)
        {
            this.context = context;
        }
        public Movie GetMovie(int id)
        {
            var movie = context.Movies.Include(m=>m.Cinema).Include(m=>m.Category).FirstOrDefault(m=>m.Id == id);
            return movie;
        }

        public ApplicationUser GetUser(string id)
        {
            var user = context.Users.Find(id);
            if(user != null)
            {
                return user;
            }
            throw new NullReferenceException();
        }
        
    }
}
