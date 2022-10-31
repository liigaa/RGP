using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Enums
{
    public enum OwnerType
    {
        [Display(Name = "Fiziska persona")]
        FiziskaPersona = 0,
        [Display(Name = "Juridiska persona")]
        JuridiskaPersona = 1
    }
}
