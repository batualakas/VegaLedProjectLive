using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace VegaLedProject.Areas.Admin.Models
{
    public class HizmetlerimizFormViewModel
    {
        public int HizmetlerimizID { get; set; }
        [Display(Name = "Başlık")]
        public string Title { get; set; }
        [Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Projenin Görseli")]
        public IFormFile File { get; set; }
    }
}
