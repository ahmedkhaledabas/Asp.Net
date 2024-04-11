using ETickets.Models;
using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }

        public int? Quantity { get; set; }

        public string MovieName { get; set; }

        [Required]
        public DateTime Date { get; set; }
       
    }
}
