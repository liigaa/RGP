using RgpWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class CreatePropertyViewModel
    {
        public int OwnerId { get; set; }

        [Display(Name = "Nosaukums")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public string PropertyName { get; set; }

        [Display(Name = "Kadastra numurs")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string PropertyNumber { get; set; }

        [Display(Name = "Īpašuma statuss")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public PropertyStatus PropertyStatus { get; set; }
    }
}
