using BikeStore.Data;
using BikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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

        public IActionResult IndexCards()
        {
            return View(context.Categories.ToList());
        }

        public IActionResult ShowProducts(int id)
        {
            TempData["categoryId"] = id;
            ViewData["Brands"] = context.Brands.ToList();
            return View(context.Products.Include(e=>e.Brand).Include(e=>e.Category).Where(e => e.CategoryId == id).ToList());
        }


        public IActionResult ShowProductsBrands(int id) {
            if (TempData["categoryId"] == null)
            {
                return RedirectToAction("IndexCards");
                // Use the shared variable here
            }
            else
            {
                ViewData["Brands"] = context.Brands.ToList();
                return View("ShowProducts", context.Products.Include(e => e.Category).Include(e => e.Brand).Where(e => e.CategoryId == (int)TempData["categoryId"]).Where(e => e.BrandId == id).ToList());

            }

        }

    }
}
