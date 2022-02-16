using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services.ProductService;
using ServiceLayer.Services.UserService;
using ServiceLayer.Services.UserService.Models;

namespace WebUI.Pages
{
    public class EditSiteModel : PageModel
    {
        private readonly IUserService _userService;
        public EditSiteModel(IUserService userService)
        {
            _userService = userService;
        }

        [BindProperty(SupportsGet =true)]
        public int ProductID { get; set; }
        [BindProperty]
        public string ProductName { get; set; }
        [BindProperty]
        public string ProductDescription { get; set; }
        [BindProperty]
        public int Price { get; set; }
        [BindProperty]
        public ProductModels product { get; set; }

        public void OnGet()
        {
            product = _userService.GetProductById(ProductID);
        }
        public IActionResult OnPost() 
        {
            _userService.CoffeUpdate(ProductID, ProductName, product.ProductDescription, Price);

            return RedirectToPage("AdminSite");
        }
    }
}
