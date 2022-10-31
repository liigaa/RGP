using System.ComponentModel.DataAnnotations;
using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class Owner : Entity
    {
        [Required]
        public string FullName { get; set; }
        [Required]
        public string RegNumber { get; set; }
        public OwnerType OwnerType { get; set; }
    }
}
