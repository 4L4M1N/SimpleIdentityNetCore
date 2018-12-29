using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace registration.Pages.Identitydemo
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message {get; set;}
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<IndexModel> _logger;
        public IndexModel(SignInManager<IdentityUser> signInManager, ILogger<IndexModel> logger)
        {
            _signInManager = signInManager;
            _logger = logger;
        }
        [BindProperty]
        public InputModel Input {get; set;}

        public class InputModel
        {
            [Required]
            public string Email {get; set;}
            [Required]
            public string Password {get; set;}
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if(ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, isPersistent:false, lockoutOnFailure:false);
                if(result.Succeeded)
                {
                    _logger.LogInformation("User Loged in");
                    return RedirectToPage("Dashboard");
                }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Page();
            }
            }
            return Page();

        }
    }
}