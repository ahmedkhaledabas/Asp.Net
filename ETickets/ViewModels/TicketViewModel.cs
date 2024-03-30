using ETickets.Models;
using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class TicketViewModel
    {
        public int id { get; set; }
        public int MovieId { get; set; }

        [Required]
        public DateTime DateTime { get; set; }

        [Range(1,10)]
        public int Quantity { get; set; }
    }
}
