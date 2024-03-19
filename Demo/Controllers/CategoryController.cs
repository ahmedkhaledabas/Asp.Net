using Demo.Data;
using Demo.Models;
using Demo.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class CategoryController : Controller
    { 
        BikeStoresContext context = new BikeStoresContext();
        public IActionResult Index()
        {
            HttpContext.Session.SetString("key", "value");
            //var categories = context.Categories;
            //List<CategoryWithNote> categoryWithNotes = new List<CategoryWithNote>();
            //foreach (var category in categories)
            //{
            //    categoryWithNotes.Add(new() { Id = category.CategoryId, Name = category.CategoryName, Note = "This is My Note" });
            //}
            //ViewData["brands"] = context.Brands;
            TempData["categoryName"] = "category name";
            return View(context.Categories);
        }

        public IActionResult CreateNew()
        {
            return View();
        }

        public IActionResult AddCategory(string category)
        {
            context.Categories.Add(new() { CategoryName = category});
            context.SaveChanges();
            return View("Index" , context.Categories);
        }

        public IActionResult Delete(int id)
        {
            var category = context.Categories.First(e => e.CategoryId == id);
            context.Categories.Remove(category);
            context.SaveChanges();
            return View("Index", context.Categories);
        }


        public IActionResult ShowProducts(int id)
        {
            ViewData["categoryName"] = context.Categories.First(e=>e.CategoryId == id).CategoryName;
            ViewData["seesion"] = HttpContext.Session.GetString("key");
            return View(context.Products.Where(e => e.CategoryId == id).ToList());
            
        }

    }
}
