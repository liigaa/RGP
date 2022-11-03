using RgpWeb.Data;
using RgpWeb.Enums;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class UnitService : EntityService<Unit>, IUnitService
    {
        private readonly IPropertyService _propertyService;
        public UnitService(IAppDbContext context, IPropertyService propertyService) : base(context)
        {
            _propertyService = propertyService;
        }

        public IEnumerable<UnitListModel> GetUnits(int id)
        {
            var propertyUnits = new List<UnitListModel>();
            var property = _propertyService.GetById(id);
            var ownerId = property.Owner.Id;
            var unitList = _context.Units.Where(unit => unit.Property.Id == id).ToList();

            foreach (var unit in unitList)
            {
                var propertyUnit = new UnitListModel
                {
                    OwnerId = ownerId,
                    PropertyId = id,
                    UnitId = unit.Id,
                    UnitNumber = unit.UnitNumber,
                    SurveyDate = unit.SurveyDate,
                    Area = unit.Area,
                    LArea = _context.UnitUseTypes.
                        FirstOrDefault(u => u.Unit.Id == unit.Id && u.LandType == LandTypeEnum.LauksaimniecibasZeme)
                        ?.TypeArea,
                    MArea = _context.UnitUseTypes.
                        FirstOrDefault(u => u.Unit.Id == unit.Id && u.LandType == LandTypeEnum.Mezs)
                        ?.TypeArea,
                    PArea = _context.UnitUseTypes.
                        FirstOrDefault(u => u.Unit.Id == unit.Id && u.LandType == LandTypeEnum.Purvs)
                        ?.TypeArea,
                    UArea = _context.UnitUseTypes.
                        FirstOrDefault(u => u.Unit.Id == unit.Id && u.LandType == LandTypeEnum.ZemUdeniem)
                        ?.TypeArea,
                    EkPaArea = _context.UnitUseTypes.
                        FirstOrDefault(u => u.Unit.Id == unit.Id && u.LandType == LandTypeEnum.ZemEkam)
                        ?.TypeArea,
                    CeluArea = _context.UnitUseTypes.
                        FirstOrDefault(u => u.Unit.Id == unit.Id && u.LandType == LandTypeEnum.ZemCeliem)
                        ?.TypeArea,
                    ParejaArea = _context.UnitUseTypes.
                        FirstOrDefault(u => u.Unit.Id == unit.Id && u.LandType == LandTypeEnum.Pareja)
                        ?.TypeArea

                };

                propertyUnits.Add(propertyUnit);
            }

            return propertyUnits;
        }

        public UnitViewModel UnitsWithPropertyId(int id)
        {
            var property = _propertyService.GetById(id);

            return new UnitViewModel
            {
                PropertyId = id,
                PropertyName = property.Title,
                UnitList = GetUnits(id)
            };
        }
    }
}
