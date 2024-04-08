using Microsoft.AspNetCore.Identity;

namespace ETickets.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string? Address { get; set; }
        public string FirstName { get; set; } = null !;
        public string? LastName { get; set; }
        public Gender Gender {  get; set; }
        public string? Image {  get; set; } = "default.jpg";
        public Cart? Cart { get; set; }

        

    }
}
