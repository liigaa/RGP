using System.ComponentModel.DataAnnotations;

namespace RgpWeb.Enums
{
    public enum LandTypeEnum
    {
        [Display(Name = "Lauksaimniecībā izmantojamā zeme")]
        LauksaimniecibasZeme = 0,
        [Display(Name = "Mežs")]
        Mezs = 1,
        Purvs = 2,
        [Display(Name = "Zeme zem ūdeņiem")]
        ZemUdeniem = 3,
        [Display(Name = "Zeme zem ēkām un pagalmiem")]
        ZemEkam = 4,
        [Display(Name = "Zeme zem ceļiem")]
        ZemCeliem = 5,
        [Display(Name = "Pārējās zemes")]
        Pareja = 6
    }
}
