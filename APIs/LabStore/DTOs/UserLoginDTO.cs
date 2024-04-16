using System.ComponentModel.DataAnnotations;

namespace LabStore.DTOs
{
    public class UserLoginDTO
    {
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
