using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Enums
{
    public enum PropertyStatus
    {
        [Display(Name = "Ir pirkšanas līgums")]
        IrPirksanasLigums,
        [Display(Name = "Apmaksāts")]
        Apmaksats,
        [Display(Name = "Reģistrēts zemes grāmatā")]
        RegistretsZemesGramata,
        [Display(Name = "Pārdots")]
        Pardots
    }
}
