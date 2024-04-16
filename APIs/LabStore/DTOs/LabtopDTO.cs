using LabStore.Models;
using System.ComponentModel.DataAnnotations;

namespace LabStore.DTOs
{
    public class LabtopDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public string? Description { get; set; }
        [Required]
        public decimal Price { get; set; }
        public string Model { get; set; } = string.Empty;
        public decimal? Discount { get; set; }

        public int? Rate { get; set; }
        public int BrandId { get; set; }
    }
}
