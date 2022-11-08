using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using RgpWeb.Data;
using RgpWeb.Enums;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class UnitUseTypesService : EntityService<UnitUseTypes>, IUnitUseTypesService
    {
        private readonly IOwnerService _ownerService;
        public UnitUseTypesService(IAppDbContext context) : base(context)
        {
            _ownerService = new OwnerService(context);
        }

        public bool IsLandTypeValid(UnitListModel unitListModel, Unit unit)
        {
            double totalTypeUseArea = 0;

            var unitUseTypeL = GetTypeByEnum(LandTypeEnum.LauksaimniecibasZeme, unitListModel);

            if (unitUseTypeL != null)
            {
                totalTypeUseArea += unitListModel.LArea ?? 0;
                if (totalTypeUseArea >= unitListModel.Area) return false;
                unitUseTypeL.TypeArea = unitListModel.LArea ?? 0;
                Update(unitUseTypeL);
            }
            else
            {
                CreateUnitUseType(unitListModel, unit, LandTypeEnum.LauksaimniecibasZeme);
            }

            var unitUseTypeM = GetTypeByEnum(LandTypeEnum.Mezs, unitListModel);

            if (unitUseTypeM != null)
            {
                totalTypeUseArea += unitListModel.MArea ?? 0;
                if (totalTypeUseArea >= unitListModel.Area) return false;
                unitUseTypeM.TypeArea = unitListModel.MArea ?? 0;
                Update(unitUseTypeM);
            }
            else
            {
                CreateUnitUseType(unitListModel, unit, LandTypeEnum.Mezs);
            }

            var unitUseTypeP = GetTypeByEnum(LandTypeEnum.Purvs, unitListModel);

            if (unitUseTypeP != null)
            {
                totalTypeUseArea += unitListModel.PArea ?? 0;
                if (totalTypeUseArea >= unitListModel.Area) return false;
                unitUseTypeP.TypeArea = unitListModel.PArea ?? 0;
                Update(unitUseTypeP);
            }
            else
            {
                CreateUnitUseType(unitListModel, unit, LandTypeEnum.Purvs);
            }

            var unitUseTypeEk = GetTypeByEnum(LandTypeEnum.ZemEkam, unitListModel);

            if (unitUseTypeEk != null)
            {
                totalTypeUseArea += unitListModel.EkPaArea ?? 0;
                if (totalTypeUseArea >= unitListModel.Area) return false;
                unitUseTypeEk.TypeArea = unitListModel.EkPaArea ?? 0;
                Update(unitUseTypeEk);
            }
            else
            {
                CreateUnitUseType(unitListModel, unit, LandTypeEnum.ZemEkam);
            }

            var unitUseTypeU = GetTypeByEnum(LandTypeEnum.ZemUdeniem, unitListModel);

            if (unitUseTypeU != null)
            {
                totalTypeUseArea += unitListModel.UArea ?? 0;
                if (totalTypeUseArea >= unitListModel.Area) return false;
                unitUseTypeU.TypeArea = unitListModel.UArea ?? 0;
                Update(unitUseTypeU);
            }
            else
            {
                CreateUnitUseType(unitListModel, unit, LandTypeEnum.ZemUdeniem);
            }

            var unitUseTypeC = GetTypeByEnum(LandTypeEnum.ZemCeliem, unitListModel);

            if (unitUseTypeC != null)
            {
                totalTypeUseArea += unitListModel.CeluArea ?? 0;
                if (totalTypeUseArea >= unitListModel.Area) return false;
                unitUseTypeC.TypeArea = unitListModel.CeluArea ?? 0;
                Update(unitUseTypeC);
            }
            else
            {
                CreateUnitUseType(unitListModel, unit, LandTypeEnum.ZemCeliem);
            }

            var unitUseTypePareja = GetTypeByEnum(LandTypeEnum.Pareja, unitListModel);

            if (unitUseTypePareja != null)
            {
                totalTypeUseArea += unitListModel.ParejaArea ?? 0;
                if (totalTypeUseArea >= unitListModel.Area) return false;
                unitUseTypePareja.TypeArea = unitListModel.ParejaArea ?? 0;
                Update(unitUseTypePareja);
            }
            else
            {
                CreateUnitUseType(unitListModel, unit, LandTypeEnum.Pareja);
            }

            return !(totalTypeUseArea > unitListModel.Area);
        }

        private void CreateUnitUseType(UnitListModel unitListModel, Unit unit, LandTypeEnum type)
        {
            var unitUseType = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = type,
                TypeArea = unitListModel.LArea ?? 0
            };

            Create(unitUseType);
        }

        private UnitUseTypes? GetTypeByEnum(LandTypeEnum type, UnitListModel unitListModel)
        {
            var unitUseType = _context.UnitUseTypes
                .Include(u => u.Owner)
                .Include(u => u.Unit)
                .SingleOrDefault(u => u.LandType == type && u.Unit.Id == unitListModel.UnitId);

           return unitUseType ?? null;
        }
    }
}
