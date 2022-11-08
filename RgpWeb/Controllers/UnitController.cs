using Microsoft.AspNetCore.Mvc;
using RgpWeb.Enums;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;
        private readonly IPropertyService _propertyService;
        private readonly IOwnerService _ownerService;
        private readonly IUnitUseTypesService _unitUseTypesService;

        public UnitController(IUnitService unitService, 
            IPropertyService propertyService, 
            IOwnerService ownerService,
            IUnitUseTypesService unitUseTypesService)
        {
            _unitService = unitService;
            _propertyService = propertyService;
            _ownerService = ownerService;
            _unitUseTypesService = unitUseTypesService;
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

            TempData["success"] = "Zemes vienība pievienota";

            return RedirectToAction("Index", "Unit", new { id = createUnitRequest.PropertyId });
        }

        //GET
        public IActionResult Edit(int id)
        {
            var objUnit = _unitService.GetUnitListModelByUnitId(id);

            return View(objUnit);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UnitListModel unitListModel)
        {
            ViewBag.Error = TempData["error"];

            if (!ModelState.IsValid) return View(unitListModel);

            var unit = _unitService.GetAllUnitById(unitListModel.UnitId);

            unit.UnitNumber = unitListModel.UnitNumber;
            unit.Area = unitListModel.Area;
            unit.SurveyDate = unitListModel.SurveyDate;

            _unitService.Update(unit);

            var isUnitUseTypesValid = _unitUseTypesService.IsLandTypeValid(unitListModel, unit);

            if (!isUnitUseTypesValid)
            {
                ModelState.AddModelError("Error", "Kopējā zemes lietojumu sadalījumu platība ir lielāka kā kopējā platība");
                return View(unitListModel);
            }

            TempData["success"] = "Zemes vienības dati laboti";

            return RedirectToAction("Index", new {id = unitListModel.PropertyId});
        }
    }
}
