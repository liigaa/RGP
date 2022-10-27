using Microsoft.AspNetCore.Mvc;
using RgpWeb.Data;

namespace RgpWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly AppDbContext _context;

        public UserController(AppDbContext context)
        {
            _context = context;
        }


        public IActionResult Index()
        {
            var objUserList = _context.Users.ToList();

            return View(objUserList);
        }
    }
}
