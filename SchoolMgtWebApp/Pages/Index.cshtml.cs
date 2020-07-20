using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet()
        {
            if (User.IsInRole(SD.AdminRole) || User.IsInRole(SD.StudentRole))
            {
                return RedirectToPage("/Students/Registration");
            }
            return LocalRedirect("/Identity/Account/Login");
        }
    }
}
