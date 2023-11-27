using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace VegaLedProject.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize("admin")]
    

    public class BaseController : Controller
    {

    }
}

