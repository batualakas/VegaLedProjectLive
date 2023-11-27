using BusinessLayer.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using VegaLedProject.Dtos.ProjelerimizDto;
using VegaLedProject.Models;

namespace VegaLedProject.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
       
        private readonly IHizmetlerimizService _hizmetlerimizService;
        public HomeController(IHizmetlerimizService hizmetlerimizService)
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
