using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class Unit : Entity
    {
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "Jābūt 11 cipariem")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Atļauti tikai cipari")]
        public string UnitNumber { get; set; }
        [Required(ErrorMessage = "Lauks ir obligāts")]
        public double Area { get; set; }
        [Required(ErrorMessage = "Lauks ir obligāts")]
        [DataValidation(ErrorMessage = "Datums nevar būt nākotnē")]
        public DateTime SurveyDate { get; set; }
        public Property Property { get; set; }
        public Owner Owner { get; set; }
    }

    public class DataValidation : ValidationAttribute
    {
        public override bool IsValid(object? value)
        {
            DateTime todayDate = Convert.ToDateTime(value);

            return todayDate <= DateTime.Now;
        }
    }
}
