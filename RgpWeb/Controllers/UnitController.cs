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

            var units = _context.Units.DistinctBy(id => id.User.Id).Include(user => user.User).ToList();
            return View(units);
        }
    }
}
