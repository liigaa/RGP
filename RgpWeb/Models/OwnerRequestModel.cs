using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class OwnerRequestModel
    {
        public int Id { get; set; }
        [Display(Name = "Vārds Uzvārds/Nosaukums")]
        public string OwnerName { get; set; }
        [Display(Name = "Īpašuma kopplatība, ha")]
        public double LandArea { get; set; }

        public OwnerRequestModel(int id, string ownerName, double landArea)
        {
            Id = id;
            OwnerName = ownerName;
            LandArea = landArea;
        }
    }
}
