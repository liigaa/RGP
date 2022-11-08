using System.ComponentModel.DataAnnotations;
using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class Owner : Entity
    {
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [Display(Name = "Vārds Uzvārds/Nosaukums")]
        public string FullName { get; set; }
        [Display(Name = "Personas kods/ Reģistrācijas Nr.")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string RegNumber { get; set; }
        [Display(Name = "Tips")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public OwnerType OwnerType { get; set; }
    }
}
