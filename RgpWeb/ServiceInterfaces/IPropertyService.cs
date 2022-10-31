using RgpWeb.Models;

namespace RgpWeb.ServiceInterfaces;

public interface IPropertyService : IEntityService<Property>
{
    IEnumerable<Property> GetPropertiesByOwnerId(int id);
}