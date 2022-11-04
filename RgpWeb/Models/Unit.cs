using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class Unit : Entity
    {
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string UnitNumber { get; set; }
        public double Area { get; set; }
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime SurveyDate { get; set; }
        public Property Property { get; set; }
        public Owner Owner { get; set; }
    }
}
