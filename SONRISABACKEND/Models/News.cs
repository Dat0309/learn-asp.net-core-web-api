namespace SONRISA_BACKEND.Models
{
    public class News
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string Desc { get; set; }
        public List<NewsContents> Contents { get; set; }
        public string Image { get; set; }
    }
}
