namespace ETickets.Models
{
    public class Ticket
    {
        public int id { get; set; }

        public int MovieId { get; set; }
        public Movie Movie { get; set; }

        public DateTime DateTime { get; set; }

        public int Quantity { get; set; }
    }
}
