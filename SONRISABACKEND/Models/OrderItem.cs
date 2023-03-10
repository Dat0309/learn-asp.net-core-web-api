namespace SONRISA_BACKEND.Models
{
    public class OrderItem
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public int Qty { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public double Price { get; set; }
        public string ProductId { get; set; }
    }
}
