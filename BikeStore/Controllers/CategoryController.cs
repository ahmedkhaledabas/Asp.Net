using BikeStore.Data;
using BikeStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace BikeStore.Controllers
{
    public class CategoryController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult Add()
        {
            return View();
        }

        public IActionResult Save(Category category)
        {
            context.Categories.Add(new() { CategoryName = category.CategoryName });
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
           var category = context.Categories.First(e => e.CategoryId == id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
