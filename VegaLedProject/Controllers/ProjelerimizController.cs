using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using VegaLedProject.Dtos.ProjelerimizDto;

namespace VegaLedProject.Controllers
{
    [AllowAnonymous]
    public class ProjelerimizController : Controller
    {
        private readonly IHizmetlerimizService _hizmetlerimizService;
        public ProjelerimizController(IHizmetlerimizService hizmetlerimizService)
        {
            _hizmetlerimizService = hizmetlerimizService;
        }
        public IActionResult Index()
        {
            var hizmetlerimizService = _hizmetlerimizService.TGetAll();
            var viewModel = hizmetlerimizService.Select(x => new ResultProjeDto
            {
                HizmetlerimizId = x.HizmetlerimizId,
                Description = x.Description,
                Title = x.Title,
                ImagePath = x.ImagePath
            }).ToList();
            return View(viewModel);
        }
    }
}
