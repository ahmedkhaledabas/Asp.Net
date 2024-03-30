using ETickets.Models;

namespace ETickets.IRepository
{
    public interface ICinemaRepository
    {
        void Delete(int id);

        void Update(Cinema cinema);

        List<Cinema> ReadAll();
        Cinema ReadById(int id);

        void Create(Cinema cinema);

        List<Movie> GetMoviesByCinema(int id);
    }
}
