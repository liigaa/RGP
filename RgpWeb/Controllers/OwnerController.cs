using Microsoft.AspNetCore.Mvc;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _userService;

        public OwnerController(IOwnerService userService)
        {
            _userService = userService;
        }


        public IActionResult Index()
        {
            var objUserList = _userService.GetUserAndTotalLandArea();

            return View(objUserList);
        }
    }
}
