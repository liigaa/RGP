using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class UnitListModel
    {
        public int OwnerId { get; set; }
        public int PropertyId { get; set; }
        public int UnitId { get; set; }
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string UnitNumber { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SurveyDate { get; set; }
        public double Area { get; set; }
        public double? LArea { get; set; }
        public double? MArea { get; set; }
        public double? PArea { get; set; }
        public double? UArea { get; set; }
        public double? EkPaArea { get; set; }
        public double? CeluArea { get; set; }
        public double? ParejaArea { get; set; }
    }
}
