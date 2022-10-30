using System.ComponentModel.DataAnnotations;
using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class Unit : Entity
    {
        [Required, StringLength(11)]
        public string UnitNumber { get; set; }
        public float Area { get; set; }
        public DateTime SurveyDate { get; set; }
        public Property Property { get; set; }
        public User User { get; set; }
    }
}
