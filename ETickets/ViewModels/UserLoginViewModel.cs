using System.ComponentModel.DataAnnotations;

namespace ETickets.ViewModels
{
    public class UserLoginViewModel
    {
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [DataType(DataType.Password)]
        [Required]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}
