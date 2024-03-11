namespace Demo.Models
{
    public class SampleProductsData
    {
        public List<Product> Products;

        public SampleProductsData()
        {
            Products = new List<Product>()
            {
                new Product() {Id = 1 , Name = "IPhone 11" , Desc = "New IPhone 11" , Price = 1200d},
                new Product() {Id = 2 , Name = "IPhone 12" , Desc = "New IPhone 12" , Price = 1500d},
                new Product() {Id = 3 , Name = "IPhone 13" , Desc = "New IPhone 13" , Price = 1800d},
                new Product() {Id = 4 , Name = "IPhone 14" , Desc = "New IPhone 14" , Price = 2000d},
                new Product() {Id = 5 , Name = "IPhone 15" , Desc = "New IPhone 15" , Price = 2200d},
            };
        }
    }
}
