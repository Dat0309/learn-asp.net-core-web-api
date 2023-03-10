namespace SONRISA_BACKEND.Models
{
    public class UserInfo
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ShippingAddress ShippingAddress { get; set; }
        
    }
}
