using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Enums
{
    public enum LandTypeEnum
    {
        [Display(Name = "Lauksaimniecībā izmantojamā zeme")]
        LauksaimniecibasZeme,
        [Display(Name = "Mežs")]
        Mezs,
        Purvs,
        [Display(Name = "Zeme zem ūdeņiem")]
        ZemUdeniem,
        [Display(Name = "Zeme zem ēkām un pagalmiem")]
        ZemEkam,
        [Display(Name = "Zeme zem ceļiem")]
        ZemCeliem,
        [Display(Name = "Pārējās zemes")]
        Pareja
    }
}
