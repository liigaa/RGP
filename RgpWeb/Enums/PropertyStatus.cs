using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Enums
{
    public enum PropertyStatus
    {
        [Display(Name = "Ir pirkšanas līgums")]
        IrPirksanasLigums = 0,
        [Display(Name = "Apmaksāts")]
        Apmaksats = 1,
        [Display(Name = "Reģistrēts zemes grāmatā")]
        RegistretsZemesGramata = 2,
        [Display(Name = "Pārdots")]
        Pardots = 3
    }
}
