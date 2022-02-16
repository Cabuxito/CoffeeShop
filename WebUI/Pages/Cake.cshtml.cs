using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services.ProductService;
using ServiceLayer.Services.ProductService.Models;
using ServiceLayer.Services.UserService;

namespace WebUI.Pages.Shared
{
    public class CakeModel : PageModel
    {
        private readonly IProductService _coffeeService;
        private readonly IUserService _userService;
        public CakeModel(IProductService coffeeService, IUserService userService)
        {
            _coffeeService = coffeeService;
            _userService = userService;
        }
        public List<ImageModels> Images { get; set; }
        public void OnGet()
        {
            Images = _coffeeService.CakeImg();
        }
        //public IActionResult OnGetBuyCake(int Id)
        //{
        //    //_userService.BuyProduct(Id);
        //    //return RedirectToPage("/Cake");
        //}
    }
}
