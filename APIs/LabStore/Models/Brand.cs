namespace LabStore.Models
{
    public class Brand
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public List<Labtop> Labtop { get; set; }
    }
}
