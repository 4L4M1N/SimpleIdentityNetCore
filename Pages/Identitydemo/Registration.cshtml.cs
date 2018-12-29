using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using registration.DataContext;

namespace registration.Pages.Identitydemo
{
    public class RegistrationModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public RegistrationModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }
        [BindProperty]
        public InputModel Input{get; set;}
        public async Task<IActionResult> OnPostAsync()
        {

            var user = new AppUser {UserName = Input.Email, Email = Input.Email, Name = Input.Name};
            var result = await _userManager.CreateAsync(user, Input.Password);
            if(result.Succeeded)
            {
                Message = "User Has been created";
                return RedirectToPage("Sucess");
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            return Page();
            //return RedirectToPage("Index");
        }

    }
}