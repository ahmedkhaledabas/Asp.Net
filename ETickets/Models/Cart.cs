namespace ETickets.Models
{
    public class Cart
    {
        public Cart()
        {
            Quantity = 1;
        }
        public int Id { get; set; }

        public int? Quantity { get; set; }

        public List<Movie>? Movies { get; set; }

        public string ApplicationUserId {  get; set; }
        public ApplicationUser ApplicationUser {  get; set; }
        
    }
    }
