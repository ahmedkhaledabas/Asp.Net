namespace ETickets.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        public string Email { get; set; } = null!;

        public Gender Gender { get; set; } 

        public string Username { get; set; } = null!;

        public string Phone { get; set; } = null!;


    }
}
