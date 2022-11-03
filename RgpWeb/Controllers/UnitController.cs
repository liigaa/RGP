using Microsoft.AspNetCore.Mvc;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Controllers
{
    public class UnitController : Controller
    {
        private readonly IUnitService _unitService;

        public UnitController(IUnitService unitService)
        {
            _unitService = unitService;
        }
        public IActionResult Index(int id)
        {
            var unitObj = _unitService.UnitsWithPropertyId(id);
            return View(unitObj);
        }
    }
}
