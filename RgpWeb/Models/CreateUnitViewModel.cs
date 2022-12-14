using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class CreateUnitViewModel
    {
        public int OwnerId { get; set; }
        public int PropertyId { get; set; }
        public string PropertyName { get; set; }
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        [Display(Name = "Kadastra apzīmējums")]
        public string UnitNumber { get; set; }
        [Display(Name = "Kopējā platība, ha")]
        [Required(ErrorMessage = "Ievadiet kopējo platību")]
        public double Area { get; set; }
        [Display(Name = "Uzmērīšanas datums")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [DataValidation(ErrorMessage = "Datums nevar būt nākotnē")]
        public DateTime SurveyDate { get; set; }
    }
}
