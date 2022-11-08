using Microsoft.EntityFrameworkCore;
using RgpWeb.Data;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class PropertyService : EntityService<Property>, IPropertyService
    {
        private readonly IOwnerService _ownerService;
        public PropertyService(IAppDbContext context) : base(context)
        {
            _ownerService = new OwnerService(context);
        }

        public OwnerPropertyViewModel GetPropertiesByOwnerId(int id)
        {
            var owner = _ownerService.GetById(id);

            return new OwnerPropertyViewModel
            {
                OwnerId = id,
                OwnerName = owner.FullName,
                Properties = _context.Properties.Where(p => p.Owner.Id == id).ToList()
            };
        }

        public Property GetPropertyWithOwnerByPropertyId(int id)
        {
            return _context.Properties.Include(p => p.Owner).First(p => p.Id == id);
        }
    }
}
