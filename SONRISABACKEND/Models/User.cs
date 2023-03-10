namespace SONRISA_BACKEND.Models
{
    public class User
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string Avatar { get; set; }
        public bool isAdmin { get; set; } = false;
    }
}
