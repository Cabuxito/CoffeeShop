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
    public class CartModel : PageModel
    {
        private readonly IProductService _coffeeService;
        private readonly IUserService _userService;

        public CartModel(IProductService coffeeService, IUserService userService)
        {
            _coffeeService = coffeeService;
            _userService = userService;
        }

        [BindProperty]
        public ProductModels product { get; set; }
        [BindProperty(SupportsGet = true)]
        public int ProductID { get; set; }
        [BindProperty]
        public int OrderAmount { get; set; }
        [BindProperty]
        public string ProductName { get; set; }
        public string orderDate { get; set; }
        [BindProperty]
        public int OrderPrice { get; set; }
        [BindProperty]
        public string OrderNote { get; set; }
        public void OnGet()
        {
            product = _userService.GetProductById(ProductID);
        }

        DateTime BuyDato = DateTime.Now;

        public IActionResult OnPostBuyCoffe()
        {
            if (ModelState.IsValid)
            {
                _userService.BuyProduct(BuyDato, ProductID, OrderAmount, ProductName, OrderPrice, OrderNote);
                return RedirectToPage("/OrderTicket");
            }

            return Page();
        }
    }
}
