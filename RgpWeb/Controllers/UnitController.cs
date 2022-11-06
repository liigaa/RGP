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
            double totalTypeUseArea = 0;

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
                TypeArea = unitListModel.LArea ?? 0
            };
            totalTypeUseArea += unitListModel.LArea ?? 0;

            if (totalTypeUseArea <= unitListModel.Area)
            {
                _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeL);
            }
            else
            {
                return View(unitListModel);
            }

            var unitUseTypeM = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.Mezs,
                TypeArea = unitListModel.MArea ?? 0
            };

            totalTypeUseArea += unitListModel.MArea ?? 0;

            if (totalTypeUseArea <= unitListModel.Area)
            {
                _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeM);
            }
            else
            {
                return View(unitListModel);
            }

            var unitUseTypeP = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.Purvs,
                TypeArea = unitListModel.PArea ?? 0
            };

            totalTypeUseArea += unitListModel.PArea ?? 0;

            if (totalTypeUseArea <= unitListModel.Area)
            {
                _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeP);
            }
            else
            {
                return View(unitListModel);
            }

            var unitUseTypeU = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.ZemUdeniem,
                TypeArea = unitListModel.UArea ?? 0
            };

            totalTypeUseArea += unitListModel.UArea ?? 0;

            if (totalTypeUseArea <= unitListModel.Area)
            {
                _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeU);
            }
            else
            {
                return View(unitListModel);
            }

            var unitUseTypeEkPa = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.ZemEkam,
                TypeArea = unitListModel.EkPaArea ?? 0
            };

            totalTypeUseArea += unitListModel.EkPaArea ?? 0;

            if (totalTypeUseArea <= unitListModel.Area)
            {
                _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeEkPa);
            }
            else
            {
                return View(unitListModel);
            }

            var unitUseTypeCeliem = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.ZemCeliem,
                TypeArea = unitListModel.CeluArea ?? 0
            };

            totalTypeUseArea += unitListModel.CeluArea ?? 0;

            if (totalTypeUseArea <= unitListModel.Area)
            {
                _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypeCeliem);
            }
            else
            {
                return View(unitListModel);
            }

            var unitUseTypePareja = new UnitUseTypes
            {
                Owner = _ownerService.GetById(unitListModel.OwnerId),
                Unit = unit,
                LandType = LandTypeEnum.Pareja,
                TypeArea = unitListModel.ParejaArea ?? 0
            };

            totalTypeUseArea += unitListModel.ParejaArea ?? 0;

            if (totalTypeUseArea <= unitListModel.Area)
            {
                _unitUseTypesService.UpdateOrAddUnitUseType(unitUseTypePareja);
            }
            else
            {
                return View(unitListModel);
            }

            return RedirectToAction("Index", new {id = unitListModel.PropertyId});
        }
    }
}
