using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class Unit : Entity
    {
        [Required, StringLength(11)]
        public string UnitNumber { get; set; }
        public float Area { get; set; }
        public DateTime SurveyDate { get; set; }
        public LandTypeEnum LandType { get; set; }
        public float TypeArea { get; set; }
        public Property Property { get; set; }
        public User User { get; set; }
    }
}
