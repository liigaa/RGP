using Microsoft.AspNetCore.Mvc;
using RgpWeb.Enums;
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

            return RedirectToAction("Index", "Unit", new { @id = createUnitRequest.PropertyId });
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
            if (!ModelState.IsValid) return View(unitListModel);

            var unit = new Unit
            {
                Id = unitListModel.UnitId,
                UnitNumber = unitListModel.UnitNumber,
                Area = unitListModel.Area,
                SurveyDate = unitListModel.SurveyDate,
                Property = _propertyService.GetById(unitListModel.PropertyId),
                Owner = _ownerService.GetById(unitListModel.OwnerId)
            };

            _unitService.Update(unit);

            var unitUseTypeL = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.LauksaimniecibasZeme,
                TypeArea = (double)unitListModel.LArea
            };

            _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeL);

            var unitUseTypeM = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.Mezs,
                TypeArea = (double)unitListModel.MArea
            };

            _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeM);

            var unitUseTypeP = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.Purvs,
                TypeArea = (double)unitListModel.PArea
            };

            _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeP);

            var unitUseTypeU = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.ZemUdeniem,
                TypeArea = (double)unitListModel.UArea
            };

            _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeU);

            var unitUseTypeEkPa = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.ZemEkam,
                TypeArea = (double)unitListModel.EkPaArea
            };

            _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeEkPa);

            var unitUseTypeCeliem = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.ZemCeliem,
                TypeArea = (double)unitListModel.CeluArea
            };

            _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeCeliem);

            var unitUseTypePareja = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.Pareja,
                TypeArea = (double)unitListModel.ParejaArea
            };

            _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypePareja);

            return RedirectToAction("Index", new { unitListModel.PropertyId});
        }
    }
}
