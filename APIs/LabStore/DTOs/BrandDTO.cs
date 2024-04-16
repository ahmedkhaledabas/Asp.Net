using System.ComponentModel.DataAnnotations;

namespace LabStore.DTOs
{
    public class BrandDTO
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
    }
}
