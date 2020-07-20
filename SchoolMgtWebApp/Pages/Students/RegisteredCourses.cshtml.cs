using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Models.ViewModal;
using SchoolMgtWebApp.Repository.IRepository;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages.Students
{
    [Authorize(Roles = SD.StudentRole)]
    public class RegisteredCoursesModel : PageModel
    {
        private readonly ICourseRegistered _courseRegRepo;
        private readonly ICourse _courseRepo;
        private readonly IStudent _studentRepo;
        public RegisteredCoursesModel(ICourseRegistered courseRegRepo, ICourse courseRepo, IStudent studentRepo)
        {
            _courseRegRepo = courseRegRepo;
            _courseRepo = courseRepo;
            _studentRepo = studentRepo;
        }

        [BindProperty]
        public DisplayCoursesVM CourseRegVM { get; set; }
        public IActionResult OnGet()
        {
            var claimIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Student studentInfo = _studentRepo.GetFisrtOrDefault(s => s.ApplicationUserId == claim.Value);
            if (studentInfo != null)
            {
                CourseRegVM = new DisplayCoursesVM
                {
                    //AllCourses = _courseRepo.GetAll(c => c.DeptId == studentInfo.DeptId).ToList(),
                    RegisteredCourses = _courseRegRepo.GetAll(c => c.StudentId == studentInfo.Id).ToList(),
                    StudentInfo = studentInfo,
                    TotalUnit=0,
                };
                var courseList = new List<Course>();
                foreach(var course in CourseRegVM.RegisteredCourses)
                {
                    var eachCourse = _courseRepo.GetFisrtOrDefault(c => c.Id == course.CourseId);
                    CourseRegVM.TotalUnit += eachCourse.CourseUnit;
                    courseList.Add(eachCourse);
                }
                CourseRegVM.AllCourses = courseList;
                return Page();
            }
            return RedirectToPage("Registration");
        }
    }
}