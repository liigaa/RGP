using RgpWeb.Data;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class PropertyService : EntityService<Property>, IPropertyService
    {
        public PropertyService(IAppDbContext context) : base(context)
        {
        }

        public IEnumerable<Property> GetPropertiesByOwnerId(int id)
        {
            return _context.Properties.Where(property => property.Owner.Id == id).ToList();
        }
    }
}
