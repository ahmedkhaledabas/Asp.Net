using BikeStore.Data;
using BikeStore.Models;
using BikeStore.Repository;
using BikeStore.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Controllers
{
    public class ProductController : Controller
    {
        ProductRepository productRepository = new ProductRepository();
        ApplicationDbContext context = new ApplicationDbContext();
        public IActionResult Index()
        {
            
            return View(productRepository.ReadAll());
        }

        public IActionResult Add()
        {
            ViewData["brands"] = context.Brands.ToList();
            ViewData["category"] = context.Categories.ToList();
            return View(new ProductModelView());
        }

        public IActionResult Save(ProductModelView product)
        {
            if (ModelState.IsValid)
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
            ViewData["brands"] = context.Brands.ToList();
            ViewData["category"] = context.Categories.ToList();
            return View("Add", product);
            //return RedirectToAction("Add" , product);


        }

        public IActionResult Delete(int id)
        {
            productRepository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            ViewData["brands"] = context.Brands.ToList();
            ViewData["category"] = context.Categories.ToList();
            var product = context.Products.First(x => x.ProductId == id);
            ProductModelView productModelView = new ProductModelView()
            {
                BrandId= product.BrandId,
                CategoryId = product.CategoryId,
                ProductName = product.ProductName,
                ProductId = product.ProductId,
                ModelYear = product.ModelYear,
                ListPrice = product.ListPrice
            };
            return View(productModelView);
        }

        public IActionResult ShowProducts(int id)
        {
            return View(context.Products.Include(e => e.Category).Where(e => e.BrandId == id).ToList());
        }


        //public IActionResult SaveChanges(int id, string productName, short modelYear, decimal listPrice, int brandId, int categoryId)
        //{
        //    var productEdite = context.Products.First(e => e.ProductId == id);
        //    productEdite.ProductName = productName;
        //    productEdite.ListPrice = listPrice;
        //    productEdite.ModelYear = modelYear;
        //    productEdite.BrandId = brandId;
        //    productEdite.CategoryId = categoryId;
        //    context.SaveChanges();
        //    return RedirectToAction("Index");
        //}

        [ValidateAntiForgeryToken]
        public IActionResult SaveChanges(Product product)
        {
            var Edite = context.Products.First(e => e.ProductId == product.ProductId);
            Edite.ProductName = product.ProductName;
            Edite.ListPrice = product.ListPrice;
            Edite.ModelYear = product.ModelYear;
            Edite.BrandId = product.BrandId;
            Edite.CategoryId = product.CategoryId;
            context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
