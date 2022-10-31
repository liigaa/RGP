using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class Unit : Entity
    {
        [Required, StringLength(11)]
        public string UnitNumber { get; set; }
        public double Area { get; set; }
        public DateTime SurveyDate { get; set; }
        public Property Property { get; set; }
        public Owner Owner { get; set; }
    }
}
