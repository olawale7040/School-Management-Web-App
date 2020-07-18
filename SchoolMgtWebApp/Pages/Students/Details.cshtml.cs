using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Repository.IRepository;

namespace SchoolMgtWebApp.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly IStudent _studentRepo;
        public DetailsModel(IStudent studentRepo)
        {
            _studentRepo = studentRepo;
        }

        [BindProperty]
        public Student StudentInfo { get; set; }
        public void OnGet()
        {
            var claimIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            var studentFromDb = _studentRepo.GetFisrtOrDefault(s => s.ApplicationUserId == claim.Value,"Department");
            StudentInfo = studentFromDb;
        }
    }
}