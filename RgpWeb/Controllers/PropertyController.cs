using Microsoft.AspNetCore.Mvc;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;
using RgpWeb.Services;

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

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //GET
        public IActionResult Redirect(int id)
        {
            return RedirectToAction("Index", "Property", new { id });
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Property property)
        {
            if (!ModelState.IsValid) return View(property);

            _propertyService.Create(property);

            return RedirectToAction("Index");
        }
    }
}
