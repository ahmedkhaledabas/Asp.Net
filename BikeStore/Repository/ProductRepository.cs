using BikeStore.Data;
using BikeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BikeStore.Repository
{
    public class ProductRepository
    {
        ApplicationDbContext context = new ApplicationDbContext();

        public void Delete(int id)
        {
            var product = context.Products.Find(id);
            if(product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
            
        }

        public void Update(Product product)
        {
            var pro = context.Products.Find(product.ProductId);
            if(pro != null)
            {
                pro.ListPrice = product.ListPrice;
                pro.ProductName = product.ProductName;
                pro.BrandId = product.BrandId;
                pro.CategoryId = product.CategoryId;
                pro.ModelYear = product.ModelYear;
                context.SaveChanges();
            }
        }

        public List<Product> ReadAll()
        {
            return context.Products.Include(e => e.Category).Include(e => e.Brand).ToList();
        }

        public Product ReadById(int id)
        {
            return context.Products.Find(id);
            
        }

        public void Create(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }


    }
}
