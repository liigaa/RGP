using Microsoft.AspNetCore.Mvc;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
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
