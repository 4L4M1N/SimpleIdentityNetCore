using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace registration.Pages.Identitydemo
{
    public class SucessModel : PageModel
    {
        public void OnGet()
        {
        }
        [TempData]
        public string Message { get; set; }
    }
}