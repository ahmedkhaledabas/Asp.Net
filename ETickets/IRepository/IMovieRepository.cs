using ETickets.Models;

namespace ETickets.IRepository
{
    public interface IMovieRepository
    {
        void incramenter(int id);
        void Delete(int id);

        void Update(Movie movie);

        List<Movie> ReadAll();
        Movie ReadById(int id);

        void Create(Movie movie);

        List<Movie> Search(string searchItem);

        List<Actor> GetActors();
        void AddActorToMovie(int movieId, int actorId);

        List<Category> GetCategories();
        List<Cinema> GetCinemas();

    }
}
