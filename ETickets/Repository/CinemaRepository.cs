using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class CinemaRepository : ICinemaRepository
    {
        ETicketsDbContext context;

        public CinemaRepository(ETicketsDbContext context)
        {
            this.context = context;
        }

        void ICinemaRepository.Create(Cinema cinema)
        {
            context.Cinemas.Add(cinema);
            context.SaveChanges();
        }

        void ICinemaRepository.Delete(int id)
        {
            var cinema = context.Cinemas.Find(id);
            if(cinema != null)
            {
                context.Cinemas.Remove(cinema);
                context.SaveChanges();
            }
        }

        List<Movie> ICinemaRepository.GetMoviesByCinema(int id)
        {
            var movies = context.Movies.Where(m => m.CinemaId == id).Include(e => e.Category).Include(e => e.Cinema).ToList();
            if(movies != null)
            {
                return movies;
            }
            throw new NullReferenceException();
        }

        List<Cinema> ICinemaRepository.ReadAll()
        {
            var cinemas = context.Cinemas.ToList();
            if(cinemas != null)
            {
                return cinemas;
            }
            throw new NullReferenceException();
        }

        Cinema ICinemaRepository.ReadById(int id)
        {
            var cinema = context.Cinemas.Find(id);
            if (cinema != null)
            {
                return cinema;
            }
            throw new NullReferenceException();
        }

        void ICinemaRepository.Update(Cinema cinema)
        {
            var findCinema = context.Cinemas.Find(cinema.Id);
            if(findCinema != null)
            {
                findCinema.Name = cinema.Name;
                findCinema.Address = cinema.Address;
                findCinema.Description = cinema.Description;
                findCinema.CinemaLogo = cinema.CinemaLogo;
                context.SaveChanges();
            }
          

        }


    }
}
