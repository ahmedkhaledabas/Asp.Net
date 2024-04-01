namespace ETickets.ViewModels
{
    public class CartViewModel
    {
        public int Id { get; set; }

        public int Quantity { get; set; }

        public int MovieId { get; set; }

        public CartViewModel()
        {
            Quantity = 1;
        }
    }
}
