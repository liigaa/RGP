using System.ComponentModel.DataAnnotations;
using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class Owner : Entity
    {
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string RegNumber { get; set; }
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public OwnerType OwnerType { get; set; }
    }
}
