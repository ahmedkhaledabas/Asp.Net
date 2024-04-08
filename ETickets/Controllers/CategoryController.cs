using ETickets.Data;
using ETickets.IRepository;
using ETickets.Models;
using ETickets.Repository;
using ETickets.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ETickets.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CategoryController : Controller
    {
        ICategoryRepository categoryRepository;

        public CategoryController(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }

        [AllowAnonymous]
        public IActionResult Index()
        {
            var categories = categoryRepository.ReadAll();
            return View(categories);
        }

        [AllowAnonymous]
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
            if (ModelState.IsValid)
            {
            var category = new Category()
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name
            };
             categoryRepository.Create(category);
             return RedirectToAction("Index");
            }
            return View("Create", categoryViewModel);
            
        }

        public IActionResult Delete(int id)
        {
            categoryRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult EditCategory(int id)
        {
            var category = categoryRepository.ReadById(id);

            var categoryViewModel = new CategoryViewModel()
            {
                Id = category.Id,
                Name = category.Name
            };
            return View(categoryViewModel);
        }

        public IActionResult SaveChanges(CategoryViewModel categoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var category = new Category()
            {
                Id = categoryViewModel.Id,
                Name = categoryViewModel.Name
            };
            categoryRepository.Update(category);
            return RedirectToAction("Index");
            }
            return View("EditCategory", categoryViewModel);
            
        }
    }
}
