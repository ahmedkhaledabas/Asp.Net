namespace ETickets.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

       public int MovieId { get; set; }

        public Movie Movie { get; set; }

        
    }
    }
