namespace LabStore.Models
{
    public class Labtop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public List<LabImages> Images { get; set; } = new List<LabImages>();
        public decimal Discount { get; set; }
        public string Model { get; set; } = string.Empty;
        public int Rate { get; set; }
        public int BrandId { get; set; }
        public Brand Brand { get; set; }
    }
}
