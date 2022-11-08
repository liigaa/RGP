using System.ComponentModel.DataAnnotations;
using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class Property : Entity
    {
        [Display(Name = "Nosaukums")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public string Title { get; set; }
        [Display(Name = "Kadastra numurs")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string PropertyNumber { get; set; }
        [Display(Name = "Status")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public PropertyStatus PropertyStatus { get; set; }
        public Owner Owner { get; set; }
    }
}
