using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Imtahan.Models
{
    public class Lumia
    {
        public int Id { get; set; }
        [Required (ErrorMessage ="Adi daxil edin:")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Title daxil edin:")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description daxil edin:")]
        public string Description { get; set; }
        public string? ImageUrl { get; set; }
        [Required(ErrorMessage = "Shekil daxil edin:")]
        [NotMapped]
        public IFormFile PhotoFile { get; set; }
    }
}
