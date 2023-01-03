using System.ComponentModel.DataAnnotations;

namespace WebShopAPI.DTOs
{
    public class RegisterDTO
    {
        [Required] public string Email { get; set; }

        [Required]
        [StringLength(8, MinimumLength = 4)]
        public string Password { get; set; }
    }
}
