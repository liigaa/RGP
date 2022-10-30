using RgpWeb.Enums;

namespace RgpWeb.Models
{
    public class UnitUseTypes : Entity
    {
        public User User { get; set; }
        public Unit Unit { get; set; }
        public LandTypeEnum LandType { get; set; }
        public float TypeArea { get; set; }
    }
}
