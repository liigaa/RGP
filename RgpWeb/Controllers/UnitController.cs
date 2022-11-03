using Microsoft.AspNetCore.Mvc;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;
using RgpWeb.Services;

namespace RgpWeb.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;
        private readonly IPropertyService _propertyService;
        private readonly IOwnerService _ownerService;

        public UnitController(IUnitService unitService, IPropertyService propertyService, IOwnerService ownerService)
        {
            _unitService = unitService;
            _propertyService = propertyService;
            _ownerService = ownerService;
        }
        public IActionResult Index(int id)
        {
            var unitObj = _unitService.UnitsWithPropertyId(id);
            return View(unitObj);
        }

        //GET
        public IActionResult Create(int id)
        {
            var property = _propertyService.GetPropertyWithOwnerByPropertyId(id);

            var model = new CreateUnitViewModel()
            {
                OwnerId = property.Owner.Id,
                PropertyId = id,
                PropertyName = property.Title
            };
            return View(model);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CreateUnitViewModel createUnitRequest)
        {
            var unit = new Unit
            {
                UnitNumber = createUnitRequest.UnitNumber,
                Area = createUnitRequest.Area,
                SurveyDate = createUnitRequest.SurveyDate,
                Property = _propertyService.GetById(createUnitRequest.PropertyId),
                Owner = _ownerService.GetById(createUnitRequest.OwnerId)
            };

            if (!ModelState.IsValid) return View(createUnitRequest);

            _unitService.Create(unit);

            return RedirectToAction("Index", "Unit", new { @id = createUnitRequest.PropertyId });
        }
    }
}
