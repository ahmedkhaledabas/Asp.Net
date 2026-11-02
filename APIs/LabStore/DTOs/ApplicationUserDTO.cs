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
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Required]
        [DataType(DataType.Password)]
        [MinLength(8)]
        public string Password { get; set; } = null!;
    }
}
