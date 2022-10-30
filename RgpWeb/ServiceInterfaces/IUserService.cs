using RgpWeb.Models;

namespace RgpWeb.ServiceInterfaces
{
    public interface IUserService : IEntityService<User>
    {
        IEnumerable<UserRequest> GetUserAndTotalLandArea();
    }
}
