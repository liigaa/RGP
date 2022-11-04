using RgpWeb.Models;

namespace RgpWeb.ServiceInterfaces
{
    public interface IUnitService : IEntityService<Unit>
    {
        IEnumerable<UnitListModel> GetUnits(int id);
        UnitViewModel UnitsWithPropertyId(int id);
        UnitListModel GetUnitListModelByUnitId(int id);
        Unit GetAllUnitById(int id);
    }
}
