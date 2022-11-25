using RgpWeb.Enums;
using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Models
{
    public class OwnerRequestModel
    {
        public int Id { get; set; }
        [Display(Name = "Vārds Uzvārds/Nosaukums")]
        public string OwnerName { get; set; }
        [Display(Name = "Personas kods/ Reģistrācijas Nr.")]
        public string RegNumber { get; set; }
        [Display(Name = "Tips")]
        public OwnerType OwnerType { get; set; }
        [Display(Name = "Īpašuma kopplatība, ha")]
        public double LandArea { get; set; }
        [Display(Name = "Īpašumu skaits")]
        public int PropertyCount { get; set; }

        public OwnerRequestModel(int id, string ownerName, string regNumber, OwnerType ownerType, double landArea, int propertyCount)
        {
            Id = id;
            OwnerName = ownerName;
            RegNumber = regNumber;
            OwnerType = ownerType;
            LandArea = landArea;
            PropertyCount = propertyCount;
        }
    }
}
