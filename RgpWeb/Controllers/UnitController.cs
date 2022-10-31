using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RgpWeb.Data;

namespace RgpWeb.Controllers
{
    public class UnitController : Controller
    {
        private readonly AppDbContext _context;

        public UnitController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {

            var users = _context.Owners.ToList();
            return View(users);
        }
    }
}
