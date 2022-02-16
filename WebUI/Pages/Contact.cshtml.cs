using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ServiceLayer.Services.ContactService;

namespace WebUI.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IContactService _ContactService;
        public ContactModel(IContactService ContactService)
        {
            _ContactService = ContactService;
        }

        [BindProperty]
        public string Email{ get; set; }
        [BindProperty]
        public string Text { get; set; }
        public bool ContactSucces { get; set; }
        public IActionResult OnPost()
        {
            ContactSucces = _ContactService.Contact(Email, Text);
            return RedirectToPage("Contact",new { status = "Success"});
        }
        public void OnGet(string status) 
        {
            if (status == "Success")
            {
                ViewData["Status"] = "Your ticket was send.";
            }
        }
    }
}
