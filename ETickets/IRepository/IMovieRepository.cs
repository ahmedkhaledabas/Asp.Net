using ETickets.Models;

namespace ETickets.IRepository
{
    public interface IMovieRepository
    {
        void Delete(int id);

        void Update(Movie movie);

        List<Movie> ReadAll();
        Movie ReadById(int id);

        void Create(Movie movie);

        List<Movie> Search(string searchItem);

    }
}
