using System.ComponentModel.DataAnnotations;

namespace SONRISA_BACKEND.Entity
{
    public class LoginEntity
    {
        [EmailAddress]
        [Required(ErrorMessage = "Email is mandatory.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Password is mandatory.")]
        public string? Password { get; set; }

    }
}
