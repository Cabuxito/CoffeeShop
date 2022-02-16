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
    public class OrderTicketModel : PageModel
    {
        private readonly IUserService _userService;

        public OrderTicketModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public OrdersModels Orders { get; set; }
        
        
        public void OnGet()
        {
            Orders = _userService.GetLastOrder();
        }
    }
}
