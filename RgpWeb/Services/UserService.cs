using RgpWeb.Data;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Services
{
    public class UserService : EntityService<User>, IUserService
    {
        private readonly IUnitService _unitService;
        public UserService(IAppDbContext context) : base(context)
        {
            _unitService = new UnitService(context);
        }

        public IEnumerable<UserRequest> GetUserAndTotalLandArea()
        {
            var userListWithArea = new List<UserRequest>();

            var userList = GetAll();

            foreach (var user in userList)
            {
                try
                {
                    var area = _context.Units.Where(unit => unit.User.Id == user.Id).Sum(unit => unit.Area);

                    userListWithArea.Add(new UserRequest(user.Id, user.FullName, area));
                }
                catch
                {
                    userListWithArea.Add(new UserRequest(user.Id, user.FullName, 0));
                }
                
            }

            return userListWithArea;
        }
    } 
}
