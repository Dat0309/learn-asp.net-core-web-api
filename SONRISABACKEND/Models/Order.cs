namespace SONRISA_BACKEND.Models
{
    public class Order
    {
        public string ID { get; set; }
        public UserInfo UserInfo { get; set; }
        public string Notes { get; set; }
        public string PaymentMethod { get; set; }
        public List<OrderItem> OrderItems { get; set; }
        public string PaymentResult { get; set; }
        public double ShippingPrice { get; set; }
        public double TotalPrice { get; set; }
        public bool IsPaid { get; set; }
        public string PaidAt { get; set; }
        public bool IsDelivered { get; set; }
        public string DeliveredAt { get; set; }
    }
}
