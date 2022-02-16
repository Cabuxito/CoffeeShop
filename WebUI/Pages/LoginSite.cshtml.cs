using ServiceLayer.Services.UserService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebUI.Pages
{
    public class LoginSiteModel : PageModel
    {
        private readonly IUserService _userService;
        public LoginSiteModel(IUserService userService)
        {
            _userService = userService;
        }
        [BindProperty]
        public string Username { get; set; }
        [BindProperty]
        public string Password { get; set; }
        [BindProperty]
        public bool NoExist { get; set; }
        public int ID { get; set; }
        public IActionResult OnPost()
        {
            return RedirectToPage(_userService.LoginUser(Username,Password));
        }
    }
}
