using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DtoLayer.Dtos.HizmetlerimizDto
{
    public class AddHizmetlerimizDto
    {
        public int HizmetlerimizId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
    }
}
