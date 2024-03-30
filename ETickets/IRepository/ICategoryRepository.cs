using ETickets.Models;

namespace ETickets.IRepository
{
    public interface ICategoryRepository
    {
        void Delete(int id);

        void Update(Category category);

        List<Category> ReadAll();
        Category ReadById(int id);

        void Create(Category category);

        List<Movie> GetMoviesByCategory(int id);
    }
}
