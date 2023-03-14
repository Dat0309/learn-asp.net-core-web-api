using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitanServices.Models
{
    public class SliderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? _id { get; set; }
        [StringLength(50)]
        public string? Title { get; set; }
        public string? Description { get; set; }
        [Required]
        public string? Image { get; set; }
        public string? Url { get; set; }
        [Required]
        public string? SlideTypeID { get; set; }
        public SliderType SliderType { get; set; }
        public string? Ordering { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}",ApplyFormatInEditMode = true)]
        public DateTime CreateAt { get; set; }
    }
}
