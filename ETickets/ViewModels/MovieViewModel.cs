using ETickets.Models;
using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class MovieViewModel
    {
        public int Id { get; set; }

        [Display(Name ="Movie")]
        [Required]
        [MaxLength(20)]
        [MinLength(4)]
        public string Name { get; set; } = null!;

        [Required]
        [MaxLength(200)]
        [MinLength(10)]
        public string Description { get; set; } = null!;

        [Range(50 , 500)]
        public decimal Price { get; set; }

        public string ImgUrl { get; set; } = null!;

        public string? TrailerUrl { get; set; }

        [Required]
        [Display(Name ="Start Date")]
        public DateTime StartDate { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDate { get; set; }

        //public MovieStatus MovieStatus { get; set; }
        [Required]
        [Display(Name ="Cinema")]
        public int CinemaId { get; set; }

        [Required]
        [Display(Name ="Category")]
        public int CategoryId { get; set; }

        public int Counter {  get; set; }
    }
}
