using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using ETickets.ViewModels;
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
            return View("/Views/Movie/Index.cshtml",categories);
        }

        public IActionResult Create()
        {
            return View(new CategoryViewModel());
        }

        public IActionResult SaveNew(CategoryViewModel categoryViewModel)
        {
            var category = new Category()
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name,
                
            };
            categoryRepository.Create(category);
            return RedirectToAction("Index");
        }
    }
}
