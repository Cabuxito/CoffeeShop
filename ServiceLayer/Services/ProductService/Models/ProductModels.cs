using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ProductService.Models
{
    public class ImageModels
    {
        public int ProductID { get; set; }
        public string ProductNames { get; set; }
        public string ProductImages { get; set; }
        public string ProductDescription { get; set; }
        public int ProductPrice { get; set; }
        public string PathToImg { get; set; }
        public string Type { get; set; }
    }
}
