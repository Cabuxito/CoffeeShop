using Microsoft.AspNetCore.Http;
using ServiceLayer.Services.ProductService.Models;
using ServiceLayer.Services.UserService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Services.ProductService
{
    public interface IProductService
    {
        public List<ImageModels> CoffeImg();
        public List<ImageModels> CakeImg();

        public void NewProduct(string Name, string Description, int Price, int Quantity, IFormFile PathToImg, string Type);
    }
}
