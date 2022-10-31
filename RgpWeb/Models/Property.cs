using System.ComponentModel.DataAnnotations;
using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class Property : Entity
    {
        [Required]
        public string Title { get; set; }
        [Required, StringLength(11)]
        public string PropertyNumber { get; set; }
        public PropertyStatus PropertyStatus { get; set; }
        public Owner Owner { get; set; }
    }
}
