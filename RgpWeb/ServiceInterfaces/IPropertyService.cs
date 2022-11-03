using RgpWeb.Models;

namespace RgpWeb.ServiceInterfaces;

public interface IPropertyService : IEntityService<Property>
{
    OwnerPropertyViewModel GetPropertiesByOwnerId(int id);
}