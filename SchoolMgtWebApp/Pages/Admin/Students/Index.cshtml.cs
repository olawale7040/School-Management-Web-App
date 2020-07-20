﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages.Admin.Students
{
    [Authorize(Roles = SD.AdminRole)]
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}