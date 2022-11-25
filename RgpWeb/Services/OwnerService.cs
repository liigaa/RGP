using RgpWeb.Data;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class OwnerService : EntityService<Owner>, IOwnerService
    {
        public OwnerService(IAppDbContext context) : base(context)
        {
        }

        public IEnumerable<OwnerRequestModel> GetUserAndTotalLandArea()
        {
            var userListWithArea = new List<OwnerRequestModel>();

            var userList = GetAll();

            foreach (var owner in userList)
            {
                var area = _context.Units.Where(unit => unit.Owner.Id == owner.Id).Sum(unit => unit.Area);
                var propertyCount = _context.Properties.Count(p => p.Owner.Id == owner.Id);

                userListWithArea.Add(new OwnerRequestModel(owner.Id, owner.FullName, owner.RegNumber, owner.OwnerType, area, propertyCount));
            }

            return userListWithArea.OrderBy(user => user.OwnerName);
        }
    } 
}
