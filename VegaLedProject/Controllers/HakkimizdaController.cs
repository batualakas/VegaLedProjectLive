using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VegaLedProject.Controllers
{
    [AllowAnonymous]
    public class HakkimizdaController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
