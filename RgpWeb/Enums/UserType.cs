using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Enums
{
    public enum UserType
    {
        [Display(Name = "Fiziska persona")]
        FiziskaPersona,
        [Display(Name = "Juridiska persona")]
        JuridiskaPerson
    }
}
