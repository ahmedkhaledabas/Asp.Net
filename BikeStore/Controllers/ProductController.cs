using BikeStore.Data;
using BikeStore.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Controllers
{
    public class ProductController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            
            return View(context.Products.Include(e=>e.Category).Include(e=>e.Brand).ToList());
        }

        public IActionResult Add()
        {
            ViewData["brands"] = context.Brands.ToList();
            ViewData["category"] = context.Categories.ToList();
            return View(new Product());
        }

        public IActionResult Save(Product product)
        {

            context.Products.Add(new()
            {
                ProductName = product.ProductName,
                ListPrice = product.ListPrice,
                ModelYear = product.ModelYear,
                BrandId = product.BrandId,
                CategoryId = product.CategoryId,

            });
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            var product = context.Products.First(e => e.ProductId == id);
            context.Products.Remove(product);
            context.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewData["brands"] = context.Brands.ToList();
            ViewData["category"] = context.Categories.ToList();
            var product = context.Products.First(x => x.ProductId == id);
            return View(product);
        }




        public IActionResult SaveChanges(int id, string productName, short modelYear, decimal listPrice, int brandId, int categoryId)
        {
            var productEdite = context.Products.First(e => e.ProductId == id);
            productEdite.ProductName = productName;
            productEdite.ListPrice = listPrice;
            productEdite.ModelYear = modelYear;
            productEdite.BrandId = brandId;
            productEdite.CategoryId = categoryId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }


        //public IActionResult SaveChanges(Product product)
        //{
        //    var Edite = context.Products.First(e => e.ProductId == product.ProductId);
        //    Edite.ProductName = product.ProductName;
        //    Edite.ListPrice = product.ListPrice;
        //    Edite.ModelYear = product.ModelYear;
        //    Edite.BrandId = product.BrandId;
        //    Edite.CategoryId = product.CategoryId;
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}
    }
}
