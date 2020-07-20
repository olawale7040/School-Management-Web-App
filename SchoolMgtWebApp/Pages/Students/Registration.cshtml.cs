using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Models.ViewModal;
using SchoolMgtWebApp.Repository.IRepository;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages.Students
{
    [Authorize]
    public class RegistrationModel : PageModel
    {
        private readonly IApplicationUser _appUser;
        private readonly IDepartment _deptRepo;
        private IWebHostEnvironment _hostEnvironment;
        private readonly IStudent _studentRepo;
        public RegistrationModel(IApplicationUser appUser, 
            IDepartment deptRepo, IWebHostEnvironment hostEnvironment,
            IStudent studentRepo
            )
        {
            _appUser = appUser;
            _deptRepo = deptRepo;
            _hostEnvironment = hostEnvironment;
            _studentRepo = studentRepo;
        }

        [BindProperty]
        public StudentViewModel StudentVM { get; set; }
        public IActionResult  OnGet()
        {
            if (User.IsInRole(SD.AdminRole))
            {
                return RedirectToPage("/Admin/Dashboard");
            }
            else
            {
                StudentVM = new StudentViewModel()
                {
                    Department = _deptRepo.GetDepartmentListOfDropDown(),
                    Student = new Student()
                };
                var claimIdentity = (ClaimsIdentity)this.User.Identity;
                var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);

                var studentFromDb = _studentRepo.GetFisrtOrDefault(s => s.ApplicationUserId == claim.Value);
                if (studentFromDb != null)
                {
                    return RedirectToPage("Details");
                }
                else
                {
                    var user = _appUser.GetFisrtOrDefault(a => a.Id == claim.Value);
                    StudentVM.Student.FirstName = user.FirstName;
                    StudentVM.Student.LastName = user.LastName;
                    StudentVM.Student.ApplicationUserId = user.Id;
                    return Page();
                }
            }
        }

        public IActionResult OnPost()
            {
            var webRootPath = _hostEnvironment.WebRootPath;
            var files = HttpContext.Request.Form.Files;
            
              if (!ModelState.IsValid)
                {
                    StudentVM.Department = _deptRepo.GetDepartmentListOfDropDown();
                    return Page();
                }
            else
            {
                var fileName = Guid.NewGuid().ToString();
                var uploads = Path.Combine(webRootPath, @"images\photos");
                var extention = Path.GetExtension(files[0].FileName);
                using (var fileStream = new FileStream(Path.Combine(uploads, fileName + extention), FileMode.Create))
                {
                    files[0].CopyTo(fileStream);
                }
                StudentVM.Student.Image = @"\images\photos\" + fileName + extention;
                _studentRepo.Add(StudentVM.Student);
                _studentRepo.Save();
                return RedirectToPage("Details");
            }
            }
    }
}