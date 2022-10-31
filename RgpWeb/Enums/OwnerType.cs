using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Enums
{
    public enum OwnerType
    {
        [Display(Name = "Fiziska persona")]
        FiziskaPersona,
        [Display(Name = "Juridiska persona")]
        JuridiskaPerson
    }
}
