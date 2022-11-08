using RgpWeb.Models;

namespace RgpWeb.ServiceInterfaces;

public interface IUnitUseTypesService
{
    bool IsLandTypeValid(UnitListModel unitListModel, Unit unit);
}