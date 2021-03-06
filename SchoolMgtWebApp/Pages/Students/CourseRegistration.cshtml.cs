﻿using System;
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
    public class CourseRegistrationModel : PageModel
    {
        private readonly ICourseRegistered _courseRegRepo;
        private readonly ICourse _courseRepo;
        private readonly IStudent _studentRepo;
        public CourseRegistrationModel(ICourseRegistered courseRegRepo, ICourse courseRepo, IStudent studentRepo)
        {
            _courseRegRepo = courseRegRepo;
            _courseRepo = courseRepo;
            _studentRepo = studentRepo;
        }

        [BindProperty]
        public CourseRegViewModel CourseRegVM { get; set; }
        public IActionResult OnGet(int deptId)
        {
            var claimIdentity = (ClaimsIdentity)this.User.Identity;
            var claim = claimIdentity.FindFirst(ClaimTypes.NameIdentifier);
            Student studentInfo = _studentRepo.GetFisrtOrDefault(s => s.ApplicationUserId == claim.Value);
            if (studentInfo != null)
            {
                CourseRegVM = new CourseRegViewModel
                {
                    AllCourses = _courseRepo.GetAll(c => c.DeptId == deptId).ToList(),
                    RegisteredCourses = _courseRegRepo.GetAll(c => c.StudentId == studentInfo.Id).ToList(),
                    StudentInfo = studentInfo
                };
                return Page();
            }
            return RedirectToPage("Registration");
        }
        public IActionResult OnPostAddCourse(int courseId, int studentId)
        {
            var courseReg = new CourseRegistered
            {
                CourseId = courseId,
                StudentId = studentId,
                DateRegistered=DateTime.Today
            };
            _courseRegRepo.Add(courseReg);
            _courseRegRepo.Save();
            return RedirectToPage("CourseRegistration", new { deptId = CourseRegVM.StudentInfo.DeptId });
        }
        public IActionResult OnPostRemoveCourse(int courseId)
        {
            var courseDB = _courseRegRepo.GetFisrtOrDefault(u => u.CourseId == courseId);
            _courseRegRepo.Remove(courseDB);
            _courseRegRepo.Save();
            return RedirectToPage("CourseRegistration", new { deptId = CourseRegVM.StudentInfo.DeptId });
        }
    }
}