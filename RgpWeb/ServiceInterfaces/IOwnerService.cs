using RgpWeb.Models;

namespace RgpWeb.ServiceInterfaces
{
    public interface IOwnerService : IEntityService<Owner>
    {
        IEnumerable<OwnerRequestModel> GetUserAndTotalLandArea();
    }
}
