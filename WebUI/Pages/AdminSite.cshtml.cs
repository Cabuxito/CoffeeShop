using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services.UserService;
using ServiceLayer.Services.UserService.Models;

namespace WebUI.Pages
{
    public class AdminSiteModel : PageModel
    {
        private readonly IUserService _userService;
        public AdminSiteModel(IUserService UserService)
        {
            _userService = UserService;
        }
        [BindProperty]
        public string adminChoice { get; set; }
        
        public List<OrdersModels> GetOrders { get; set; }
        public List<CoffeeModels> GetCoffee { get; set; }
        public List<CakeModels> GetCake { get; set; }
        public bool CoffeeCheck { get; set; }
        public bool OrdersCheck { get; set; }
        public bool CakeCheck { get; set; }
        public void OnPost()
        {
            switch (adminChoice)
            {
                case "Orders":
                    OrdersCheck = true;
                    GetOrders = _userService.GetOrders();
                    break;
                case "Coffee":
                    CoffeeCheck = true;
                    GetCoffee = _userService.GetCoffee();
                    break;
                case "Cakes":
                    CakeCheck = true;
                    GetCake = _userService.GetCake();
                    break;
                default:
                    break;
            }
        }
        public IActionResult OnPostDeleteOrder(int orderId) 
        {
            _userService.DeleteOrderById(orderId);
            return RedirectToPage(new { status = "Success" });
        }
        public IActionResult OnPostDeleteProduct(int productID) 
        {
            _userService.DeleteProductById(productID);
            return RedirectToPage(new { status = "Success" });
        }
        public void OnGet(string status) 
        {
            if (status == "Success")
            {
                ViewData["Status"] = "Item was deleted.";
            }
        }
    }
}
