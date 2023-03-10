namespace SONRISA_BACKEND.Models
{
    public class ProductCategories
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<SubCategories> SubCategories { get; set; }

    }
}
