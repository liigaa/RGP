using RgpWeb.Data;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class UnitService : EntityService<Unit>, IUnitService
    {
        public UnitService(IAppDbContext context) : base(context)
        {
        }
    }
}
