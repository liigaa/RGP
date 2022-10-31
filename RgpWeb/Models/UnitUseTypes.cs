using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class UnitUseTypes : Entity
    {
        public Owner Owner { get; set; }
        public Unit Unit { get; set; }
        public LandTypeEnum LandType { get; set; }
        public double TypeArea { get; set; }
    }
}
