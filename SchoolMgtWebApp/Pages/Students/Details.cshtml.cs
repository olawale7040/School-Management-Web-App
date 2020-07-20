using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Repository.IRepository;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages.Students
{
    [Authorize(Roles = SD.StudentRole)]
    public class DetailsModel : PageModel
    {
        private readonly IStudent _studentRepo;
        private readonly IApplicationUser _appUserRepo;
        public DetailsModel(IStudent studentRepo, IApplicationUser appUserRepo)
        {
            _studentRepo = studentRepo;
            _appUserRepo = appUserRepo;
        }

        [BindProperty]
        public Student StudentInfo { get; set; }
        public IActionResult OnGet()
        {
            var claimIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var studentFromDb = _studentRepo.GetFisrtOrDefault(s => s.ApplicationUserId == claim.Value, "Department");
            if (studentFromDb!=null){
                studentFromDb.ApplicationUser = _appUserRepo.GetFisrtOrDefault(s => s.Id == claim.Value);
                StudentInfo = studentFromDb;
                return Page();
            }
            else
            {
                return RedirectToPage("Registration");
            }
            
        }
    }
}