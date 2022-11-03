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

        public OwnerPropertyViewModel GetPropertiesByOwnerId(int id)
        {
            return new OwnerPropertyViewModel
            {
                OwnerId = id,
                Properties = _context.Properties.Where(property => property.Owner.Id == id).ToList()
            };
        }
    }
}
