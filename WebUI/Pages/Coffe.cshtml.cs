using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services.ProductService;
using ServiceLayer.Services.ProductService.Models;
using ServiceLayer.Services.UserService;
using ServiceLayer.Services.UserService.Models;

namespace WebUI.Pages
{
    public class CoffeModel : PageModel
    {
        private readonly IProductService _coffeeService;
        private readonly IUserService _userService;

        public CoffeModel(IProductService coffeeService, IUserService userService)
        {
            _coffeeService = coffeeService;
            _userService = userService;
        }

        public List<ImageModels> Images { get; set; }

        public void OnGet()
        {
            Images = _coffeeService.CoffeImg();
        }
        
    }
}
