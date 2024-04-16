using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace LabStore.DTOs
{
    public class ApplicationUserDTO
    {
        [Required]
        public string FirstName { get; set; } = null!;
        public string? LastName { get; set; }

        [Required]
        public string UserName { get; set; } = null!;
        [Required]
        [Unicode]
        [RegularExpression("^[\\w-\\.]+@([\\w-]+\\.)+[\\w-]{2,4}$", ErrorMessage = "Email Must Contain @gmail Or yahoo.com")]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [RegularExpression("^(?=.*\\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$", ErrorMessage = "Password Must at least 8 Char Contain Special Char , Number , Upper,Lower Char")]
        public string PasswordHash { get; set; } = null!;
    }
}
