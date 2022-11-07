using Microsoft.EntityFrameworkCore;
using NuGet.Protocol;
using RgpWeb.Data;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class UnitUseTypesService : EntityService<UnitUseTypes>, IUnitUseTypesService
    {
        public UnitUseTypesService(IAppDbContext context) : base(context)
        {
        }

        public void UpdateOrAddUnitUseType(UnitUseTypes type)
        {
            var unitUseType = _context.UnitUseTypes
                .Include(u => u.Owner)
                .Include(u => u.Unit)
                .SingleOrDefault(u => u.LandType == type.LandType && u.Unit.Id == type.Unit.Id);

            if (unitUseType != null)
            {
                unitUseType.TypeArea = type.TypeArea;

                Update(unitUseType);
            }
            else
            {
                Create(type);
            }
        }
    }
}
