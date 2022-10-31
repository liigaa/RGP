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

        //POST
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Create(Owner owner)
        //{
        //    if (!ModelState.IsValid) return View(owner);

        //    _propertyService.Create(owner);

        //    return RedirectToAction("Index");
        //}
    }
}
