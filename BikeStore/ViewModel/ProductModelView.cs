using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BikeStore.ViewModel
{
    public class ProductModelView
    {
        public int ProductId { get; set; }

        [Required]
        public string ProductName { get; set; } = null!;

        [Required]
        public int BrandId { get; set; }

        [Required]

        public int CategoryId { get; set; }

        [Range(1990,2024) ]
        public short ModelYear { get; set; }

        [Range(100,1000)]
        public decimal ListPrice { get; set; }
    }
}
