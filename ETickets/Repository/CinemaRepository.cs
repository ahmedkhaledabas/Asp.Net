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
            throw new NotImplementedException();
        }

        void ICinemaRepository.Delete(int id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        void ICinemaRepository.Update(Cinema cinema)
        {
            throw new NotImplementedException();
        }


    }
}
