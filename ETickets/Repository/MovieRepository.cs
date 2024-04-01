using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace ETickets.Repository
{
    public class MovieRepository : IMovieRepository
    {
        ETicketsDbContext context;

        public MovieRepository(ETicketsDbContext eTicketsDbContext)
        {
            this.context = eTicketsDbContext;
        }

        public void Create(Movie movie)
        {
           context.Movies.Add(movie);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            var movie = context.Movies.Find(id);
            if(movie != null)
            {
                context.Movies.Remove(movie);
                context.SaveChanges();
            }
        }

        public List<Actor> GetActors() => context.Actors.Select(a => new Actor { Id = a.Id, FirstName = a.FirstName }).ToList();

        public void incramenter(int id)
        {
            var movie = context.Movies.Find(id);
            if (movie != null)
            {
                movie.Counter++;
                context.SaveChanges();
            }
        }
        public List<Movie> ReadAll()=> context.Movies.Include(e => e.Category).Include(e => e.Cinema).ToList();
        

        public Movie ReadById(int id)
        {
            var movie = context.Movies.Include(m => m.Actors)
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .FirstOrDefault(m => m.Id == id);
            if(movie != null)
            {
                return movie;
            } return movie;
           
        }

        public void Update(Movie movie)
        {
            var findMovie = context.Movies.Find(movie.Id);
            if(findMovie != null)
            {
                findMovie.Name = movie.Name;
                findMovie.StartDate = movie.StartDate;
                findMovie.EndDate = movie.EndDate;
                findMovie.MovieStatus = movie.MovieStatus;
                findMovie.CategoryId = movie.CategoryId;
                findMovie.CinemaId = movie.CinemaId;
                findMovie.Description = movie.Description;
                findMovie.Price = movie.Price;
                findMovie.ImgUrl = movie.ImgUrl;
                findMovie.TrailerUrl = movie.TrailerUrl;

                context.SaveChanges();
            }
        }

        List<Movie> IMovieRepository.Search(string searchItem)
        {
            var SearchItems = context.Movies
                .Include(m => m.Category)
                .Include(m => m.Cinema)
                .Where(m => m.Name.Contains(searchItem)).ToList();
            return SearchItems;
        }
    }
}
