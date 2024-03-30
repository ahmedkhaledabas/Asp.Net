using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        ETicketsDbContext context;

        public CategoryRepository(ETicketsDbContext context)
        {
            this.context = context;
        }
        void ICategoryRepository.Create(Category category)
        {
            throw new NotImplementedException();
        }

        void ICategoryRepository.Delete(int id)
        {
            throw new NotImplementedException();
        }

        List<Category> ICategoryRepository.ReadAll()
        {
            var categories = context.Categories.ToList();
            return categories;
        }

        List<Movie> ICategoryRepository.GetMoviesByCategory(int id)
        {
            var movies = context.Movies.Where(m => m.CategoryId == id).Include(e => e.Category).Include(e => e.Cinema).ToList();
            if (movies != null)
            {
                return movies;
            }
            throw new NullReferenceException();
        }
        Category ICategoryRepository.ReadById(int id)
        {
            throw new NotImplementedException();
        }

        void ICategoryRepository.Update(Category category)
        {
            throw new NotImplementedException();
        }

    }
}
