using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TitanServices.Models
{
    public class PostType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? _id { get; set; }
        [Required]
        public string? Title { get; set; }

        public ICollection<PostModel> Posts { get; set; }
    }
}
