using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitanServices.Models
{
    public class SliderType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string? _id { get; set; }
        [Required]
        public string? Title { get; set; }
        public string? Description { get; set; }
        
        public ICollection<SliderModel> Sliders { get; set; }
    }
}
