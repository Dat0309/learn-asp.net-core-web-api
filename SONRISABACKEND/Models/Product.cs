namespace SONRISA_BACKEND.Models
{
    public class Product
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
        public int Price { get; set; }
        public int CountInStock { get; set; }
        public bool Active { get; set; }
        public double Discount { get; set; }
        public string CategoriesId { get; set; }
        public List<Size> Sizes { get; set; }

    }
}
