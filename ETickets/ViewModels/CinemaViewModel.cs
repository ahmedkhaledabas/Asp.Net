using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string CinemaLogo { get; set; } = null!;

        [Required]
        [MaxLength(50)]
        public string Address { get; set; } = null!;
    }
}
