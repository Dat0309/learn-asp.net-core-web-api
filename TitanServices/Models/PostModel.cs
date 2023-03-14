using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TitanServices.Models
{
    public class PostModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? _id { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        [Required]
        public string? ShortDesc { get; set; }
        [Required]
        public string? FullDesc { get; set; }
        [Required]
        public string? Image { get; set; }
        public string? Url { get; set; }
        [Required]
        public string? PostTypeID { get; set; }
        public PostType PostType { get; set; }
        public string? Author { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; }
    }
}
