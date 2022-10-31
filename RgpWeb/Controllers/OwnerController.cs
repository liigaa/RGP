using Microsoft.AspNetCore.Mvc;
using RgpWeb.Models;
using RgpWeb.ServiceInterfaces;

namespace RgpWeb.Controllers
{
    public class OwnerController : Controller
    {
        private readonly IOwnerService _ownerService;

        public OwnerController(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }


        public IActionResult Index()
        {
            var objOwnerList = _ownerService.GetUserAndTotalLandArea();

            return View(objOwnerList);
        }

        //GET
        public IActionResult Create()
        {
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Owner owner)
        {
            if (!ModelState.IsValid) return View(owner);

            _ownerService.Create(owner);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Edit(int id)
        {
            var objOwner = _ownerService.GetById(id);
            return View(objOwner);
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Owner owner)
        {
            if (!ModelState.IsValid) return View(owner);

            _ownerService.Update(owner);

            return RedirectToAction("Index");
        }

        //GET
        public IActionResult Redirect(int id)
        {
            return RedirectToAction("Index", "Property", new {id});
        }
    }
}
