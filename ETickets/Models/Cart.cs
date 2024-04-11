namespace ETickets.Models
{
    public class Cart
    {
        public int Id { get; set; }

        public int? Quantity { get; set; }

        public string MovieName {  get; set; }

        public DateTime Date { get; set; }
        public string ApplicationUserId {  get; set; }
        public ApplicationUser ApplicationUser {  get; set; }
        
    }
    }
