using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services.UserService;
using System.Threading;

namespace WebUI.Pages.Shared
{
    public class CreateUserModel : PageModel
    {
        //private readonly string connectionString;
        //public CreateUserModel(IConfiguration config) 
        //{ 
        //    connectionString = config.GetConnectionString("SQLConnectionString"); 
        //}
        private readonly IUserService _userService;
        public CreateUserModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string Lastname { get; set; }
        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public int Phone { get; set; }
        public bool CreateSucces { get; set; }

        public IActionResult OnPost()
        {
            CreateSucces = _userService.AddUser(Username, Password, Password, Name, Lastname, Email, Phone, CreateSucces);
            return Page();
        }
    }
}
