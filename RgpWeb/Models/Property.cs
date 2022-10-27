using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class Property : Entity
    {
        [Required]
        public string Title { get; set; }
        [Required, StringLength(11)]
        public string PropertyNumber { get; set; }
        public string Status { get; set; }
        public User User { get; set; }
    }
}
