using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using VegaLedProject.Areas.Admin.Models;

namespace VegaLedProject.Areas.Admin.Controllers
{
    public class RoleController : BaseController
    {
        private readonly RoleManager<AppRole> _roleManager;
        public RoleController(RoleManager<AppRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult CreateRole()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateRole(RoleViewModel model)
        {
            if (ModelState.IsValid)
            {
                AppRole role = new AppRole
                {
                    Name = model.Name,
                };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }

            }
            return View(model);

        }
    }
}
