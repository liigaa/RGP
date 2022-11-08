using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class UnitListModel
    {
        public int OwnerId { get; set; }
        public int PropertyId { get; set; }
        public int UnitId { get; set; }
        [Display(Name = "Kadastra apzīmējums")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string UnitNumber { get; set; }
        [Display(Name = "Uzmērīšanas datums")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [DataValidation(ErrorMessage = "Datums nevar būt nākotnē")]
        public DateTime SurveyDate { get; set; }
        [Display(Name = "Kopplatība, ha")]
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public double Area { get; set; }
        [Display(Name = "Lauksaimniecībā izmantojamā zeme, ha")]
        public double? LArea { get; set; }
        [Display(Name = "Meža zeme, ha")]
        public double? MArea { get; set; }
        [Display(Name = "Purvs, ha")]
        public double? PArea { get; set; }
        [Display(Name = "Ūdens objektu zeme, ha")]
        public double? UArea { get; set; }
        [Display(Name = "Zeme zem ēkām un pagalmiem, ha")]
        public double? EkPaArea { get; set; }
        [Display(Name = "Zeme zem ceļiem, ha")]
        public double? CeluArea { get; set; }
        [Display(Name = "Pārējā zeme, ha")]
        public double? ParejaArea { get; set; }
    }
}
