using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class User : Entity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string RegNumber { get; set; }
        public string Type { get; set; }
    }
}
