using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Linq;
using System;
using BusinessLayer.Abstract;
using VegaLedProject.Areas.Admin.Models;
using VegaLedProject.Dtos.ProjelerimizDto;
using EntityLayer.Concrete;
using BusinessLayer.Concrete;
using DataAccessLayer.EntityFramework;
using DataAccessLayer.Abstract;
using AutoMapper;

namespace VegaLedProject.Areas.Admin.Controllers
{
   
    public class HomeController : BaseController
    {
        private readonly IMapper _mapper;
        private readonly IHizmetlerimizService _hizmetlerimizService;
        private readonly IWebHostEnvironment _environment;
        public HomeController(IHizmetlerimizService hizmetlerimizService, IWebHostEnvironment environment, IMapper mapper)
        {
            _mapper = mapper;
            _hizmetlerimizService = hizmetlerimizService;
            _environment = environment;
        }

        public IActionResult Index()
        {
            var values = _hizmetlerimizService.TGetAll();

            return View(values);
        }

        [HttpGet]
        public IActionResult New()
        {

            return View("form", new HizmetlerimizFormViewModel());
        }
        [HttpPost]
        public IActionResult Save(HizmetlerimizFormViewModel formData)
        {
            var allowedFileContentTypes = new string[] { "image/jpeg", "image/jpg", "image/png", "image/jfif" };
            var allowedFileExtensions = new string[] { ".jpg", ".jpeg", ".png", ".jfif" };

            var fileContentType = formData.File.ContentType;
            var fileNameWithoutExtension = Path.GetFileNameWithoutExtension(formData.File.FileName);
            var fileExtension = Path.GetExtension(formData.File.FileName);
            if (formData.File == null || formData.File.Length == 0 || !allowedFileContentTypes.Contains(fileContentType) || !allowedFileExtensions.Contains(fileExtension))
            {
                ModelState.AddModelError("file", "Lütfen jpg , jpeg, jfif veya png tipinde geçerli bir dosya yükleyiniz.");
                return View("form", formData);
            }
            var newFileName = fileNameWithoutExtension + "_" + Guid.NewGuid() + fileExtension;
            var folderPath = Path.Combine("images", "OurServices");
            var wwwRootFolderPath = Path.Combine(_environment.WebRootPath, folderPath);
            var wwwRootFilePath = Path.Combine(wwwRootFolderPath, newFileName);

            Directory.CreateDirectory(wwwRootFolderPath);

            using (var fileStream = new FileStream(wwwRootFilePath, FileMode.Create))
            {
                formData.File.CopyTo(fileStream);
            }
            if (formData.HizmetlerimizID == 0)
            {
              
                var resultProjeDto = new ResultProjeDto()
                {
                    HizmetlerimizId = formData.HizmetlerimizID,
                    Description = formData.Description,
                    Title = formData.Title,
                    ImagePath = newFileName
                };
                var values = _mapper.Map<Hizmetlerimiz>(resultProjeDto);
                _hizmetlerimizService.TAdd(values);
                
                if (ModelState.IsValid)
                {
                    return RedirectToAction("index");
                }
                else
                {
                   
                    return View("form", formData);
                }
            }
            else
            {
                var resultProjeDto = new ResultProjeDto()
                {
                    HizmetlerimizId = formData.HizmetlerimizID,
                    Description = formData.Description,
                    Title = formData.Title,
                };
                if (formData.File != null)
                {
                    resultProjeDto.ImagePath = newFileName;
                    var values = _mapper.Map<Hizmetlerimiz>(resultProjeDto);
                    _hizmetlerimizService.TUpdate(values);
                }
                return RedirectToAction("index");
            }
        }

       

        public IActionResult Delete(int id)
        {
            var hizmetlerimizService = _hizmetlerimizService.TGetById(id);
            _hizmetlerimizService.TDelete(id);

            return RedirectToAction("index");
        }
    }
}
