using Microsoft.AspNetCore.Mvc;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;

        public PropertyController(IPropertyService propertyService)
        {
            _propertyService = propertyService;
        }
        public IActionResult Index(int id)
        {
            var ownerProperties = _propertyService.GetPropertiesByOwnerId(id);

            return View(ownerProperties);
        }
    }
}
