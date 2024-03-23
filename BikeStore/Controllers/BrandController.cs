using BikeStore.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Controllers
{
    public class BrandController : Controller
    {

        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            return View(context.Brands.ToList());
        }

        public IActionResult IndexCards()
        {
            return View(context.Brands.ToList());
        }

        public IActionResult ShowProducts(int id)
        {
            return View(context.Products.Include(e => e.Category).Where(e => e.BrandId == id).ToList());
        }
    }
}
