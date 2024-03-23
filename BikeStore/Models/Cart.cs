namespace BikeStore.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ListPrice { get; set; }

        public Product Product { get; set; } = null!;
    }
}
