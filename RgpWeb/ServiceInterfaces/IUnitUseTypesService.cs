using RgpWeb.Models;

namespace RgpWeb.ServiceInterfaces;

public interface IUnitUseTypesService
{
    void UpdateOrAddUnitUseType(UnitUseTypes type);
}