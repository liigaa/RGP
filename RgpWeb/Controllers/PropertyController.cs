using Microsoft.AspNetCore.Mvc;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;
using RgpWeb.Services;

namespace RgpWeb.Controllers
{
    public class PropertyController : Controller
    {
        private readonly IPropertyService _propertyService;
        private readonly IOwnerService _ownerService;

        public PropertyController(IPropertyService propertyService, IOwnerService ownerService)
        {
            _propertyService = propertyService;
            _ownerService = ownerService;
        }
        public IActionResult Index(int id)
        {
            var ownerProperties = _propertyService.GetPropertiesByOwnerId(id);
            return View(ownerProperties);
        }

        //GET
        public IActionResult Create(int id)
        {
            var model = new CreatePropertyViewModel
            {
                OwnerId = id
            };
            return View(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreatePropertyViewModel createPropertyRequest)
        {
            var property = new Property
            {
                PropertyStatus = createPropertyRequest.PropertyStatus,
                PropertyNumber = createPropertyRequest.PropertyNumber,
                Title = createPropertyRequest.PropertyName,
                Owner = _ownerService.GetById(createPropertyRequest.OwnerId)
            };

            if (!ModelState.IsValid) return View(createPropertyRequest);

            _propertyService.Create(property);

            TempData["success"] = "Zemes īpašums pievienots";

            return RedirectToAction("Index", "Property", new {@id = createPropertyRequest.OwnerId});
        }

        //GET
        public IActionResult Edit(int id)
        {
            var objProperty = _propertyService.GetPropertyWithOwnerByPropertyId(id);
            return View(objProperty);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Property property)
        {
            if (!ModelState.IsValid) return View(property);

            _propertyService.Update(property);

            TempData["success"] = "Zemes īpašuma dati laboti";

            return RedirectToAction("Index", new {property.Owner.Id});
        }

        //GET
        public IActionResult Redirect(int id)
        {
            return RedirectToAction("Index", "Unit", new { id });
        }
    }
}
