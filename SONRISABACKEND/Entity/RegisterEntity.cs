using System.ComponentModel.DataAnnotations;

namespace SONRISA_BACKEND.Entity
{
    public class RegisterEntity
    {
        [Required(ErrorMessage = "ID is mandatory.")]
        public string ID { get; set; }
        [Required(ErrorMessage ="Name is mandatory.")]
        public string? Name { get; set; }
        [EmailAddress]
        [Required(ErrorMessage = "Email is mandatory.")]
        public string? Email { get; set; }
        [Required(ErrorMessage = "Password is mandatory.")]
        public string? Password { get; set; }
        [Required(ErrorMessage = "Avatar is mandatory.")]
        public string? Avatar { get; set; }

        public bool isAdmin { get; set; } = false;
    }
}
