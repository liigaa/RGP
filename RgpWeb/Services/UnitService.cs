using Microsoft.EntityFrameworkCore;
using RgpWeb.Data;
using RgpWeb.Enums;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class UnitService : EntityService<Unit>, IUnitService
    {
        private readonly IPropertyService _propertyService;
        public UnitService(IAppDbContext context) : base(context)
        {
            _propertyService = new PropertyService(context);
        }

        public IEnumerable<UnitListModel> GetUnits(int id)
        {
            var propertyUnits = new List<UnitListModel>();
            var property = _propertyService.GetPropertyWithOwnerByPropertyId(id);
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
            var property = _propertyService.GetPropertyWithOwnerByPropertyId(id);

            return new UnitViewModel
            {
                PropertyId = id,
                OwnerId = property.Owner.Id,
                PropertyName = property.Title,
                UnitList = GetUnits(id)
            };
        }

        public Unit GetAllUnitById(int id)
        {
            return _context.Units.Include(u => u.Owner)
                .Include(u => u.Property).First(u => u.Id == id);
        }

        public UnitListModel GetUnitListModelByUnitId(int id)
        {
            var unit = GetAllUnitById(id);
            var property = _propertyService.GetPropertyWithOwnerByPropertyId(unit.Property.Id);
            var ownerId = property.Owner.Id;
            

            return new UnitListModel
            {
                OwnerId = ownerId,
                PropertyId = property.Id,
                UnitId = id,
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

        }
    }
}
