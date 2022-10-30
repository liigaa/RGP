using System.ComponentModel.DataAnnotations;
using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class User : Entity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string RegNumber { get; set; }
        public UserType UserType { get; set; }
    }
}
