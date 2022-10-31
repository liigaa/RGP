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

        public IEnumerable<OwnerRequest> GetUserAndTotalLandArea()
        {
            var userListWithArea = new List<OwnerRequest>();

            var userList = GetAll();

            foreach (var owner in userList)
            {
                try
                {
                    var area = _context.Units.Where(unit => unit.Owner.Id == owner.Id).Sum(unit => unit.Area);

                    userListWithArea.Add(new OwnerRequest(owner.Id, owner.FullName, area));
                }
                catch
                {
                    userListWithArea.Add(new OwnerRequest(owner.Id, owner.FullName, 0));
                }
                
            }

            return userListWithArea;
        }
    } 
}
