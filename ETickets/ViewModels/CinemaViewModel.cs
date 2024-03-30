namespace ETickets.ViewModels
{
    public class CinemaViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;
        public string Description { get; set; } = null!;

        public string CinemaLogo { get; set; } = null!;
        public string Address { get; set; } = null!;
    }
}
