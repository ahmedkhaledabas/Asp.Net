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
            context.Categories.Add(category);
            context.SaveChanges();
        }

        void ICategoryRepository.Delete(int id)
        {
            var category = context.Categories.Find(id);
            if(category != null)
            {
                context.Categories.Remove(category);
                context.SaveChanges();
            }
            
        }

        List<Category> ICategoryRepository.ReadAll()
        {
            var categories = context.Categories.ToList();
            if(categories != null)
            {
                return categories;
            }
            throw new NullReferenceException();
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
            var category = context.Categories.Find(id);
            if(category != null)
            {
                return category;
            }
            throw new NullReferenceException();
        }

        void ICategoryRepository.Update(Category category)
        {
            var findCategory = context.Categories.Find(category.Id);
            if(findCategory != null)
            {
                findCategory.Name = category.Name;
                findCategory.Id = category.Id;
                context.SaveChanges();
            }
            
            
        }

    }
}
