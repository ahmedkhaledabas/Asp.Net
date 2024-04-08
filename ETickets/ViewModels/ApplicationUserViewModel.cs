using ETickets.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class ApplicationUserViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }

        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [Unicode]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Email Must Contain @gmail Or yahoo.com")]
        public string Email { get; set; } = null!;

        public string? Address { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Password")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password Must at least 8 Char Contain Special Char , Number , Upper,Lower Char")]
        public string PasswordHash { get; set; } = null!;

        [Required]
        [Display(Name ="Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("PasswordHash")]
        public string ConfirmedPassword {  get; set; } = null!;

        [Required(ErrorMessage = "Please select a gender")]
        public Gender Gender { get; set; }

        [Required]
        [RegularExpression("^(\\+201|01|00201)[0-2,5]{1}[0-9]{8}", ErrorMessage = "Phone Must Be Contain 11 Digit Like 01284338087")]
        public string? PhoneNumber { get; set; }

        public string? Image { get; set; }

        
    }
}
