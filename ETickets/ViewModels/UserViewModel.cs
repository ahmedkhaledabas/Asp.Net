using ETickets.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class UserViewModel
    {

        [Required]
        public string FirstName { get; set; } = null!;

        public string? LastName { get; set; }

        [Required ,Unicode, RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$" , ErrorMessage = "Email Must Contain @gmail Or yahoo.com")]
        public string Email { get; set; } = null!;

        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$" , ErrorMessage ="Password Must at least 8 Char Contain Special Char , Number , Upper,Lower Char")]
        public string Password { get; set; } = null!;

        public string ConfirmPassword { get; set; } = null!;
        [Required]
        public Gender Gender { get; set; }

        [Required , Unicode]
        public string Username { get; set; } = null!;

        [Required , RegularExpression("^(\\+201|01|00201)[0-2,5]{1}[0-9]{8}" , ErrorMessage ="Phone Must Like 01284338087")]
        public string Phone { get; set; } = null!;
    }
}
