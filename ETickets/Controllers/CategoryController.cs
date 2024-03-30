using ETickets.Data;
using ETickets.IRepository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    public class CategoryController : Controller
    {
        ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public IActionResult Index()
        {
            var categories = categoryRepository.ReadAll();
            return View(categories);
        }

        public IActionResult ShowMovies(int id)
        {
            var categories = categoryRepository.GetMoviesByCategory(id);
            return View("/Views/Home/Index.cshtml",categories);
        }
    }
}
