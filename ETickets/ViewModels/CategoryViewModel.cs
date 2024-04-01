using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Name { get; set; }
    }
}
