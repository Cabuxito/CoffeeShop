using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services.ProductService;

namespace WebUI.Pages
{
    public class NewProductSiteModel : PageModel
    {
        private readonly IProductService _productService;

        public NewProductSiteModel(IProductService productService) 
        {
            _productService = productService;
        }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Description { get; set; }
        [BindProperty]
        public int Price { get; set; }
        [BindProperty]
        public int Quantity { get; set; }
        [BindProperty]
        public string Type { get; set; }
        [BindProperty]
        public IFormFile UploadFile { get; set; }

        public IActionResult OnPost()
        {
            _productService.NewProduct(Name,Description,Price,Quantity,UploadFile,Type);
            return RedirectToPage("/AdminSite");
        }
    }
}
