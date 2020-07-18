using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Models.ViewModal;
using SchoolMgtWebApp.Repository.IRepository;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages.Admin.Courses
{
    [Authorize(Roles = SD.AdminRole)]
    public class UpSertModel : PageModel
    {
        private IDepartment _deptRepo;
        private ICourse _courseRepo;
        public UpSertModel(IDepartment deptRepo, ICourse courseRepo)
        {
            _deptRepo = deptRepo;
            _courseRepo = courseRepo;
        }

        [BindProperty]
        public CourseViewModel CourseVM { get; set; }
        public IActionResult OnGet(int? id)
        {
            CourseVM = new CourseViewModel()
            {
                Course =  new Course(),
                Department = _deptRepo.GetDepartmentListOfDropDown(),
            };
            if (id != null)
            {
                var courseFromDb = _courseRepo.GetFisrtOrDefault(m => m.Id == id);
                if (courseFromDb == null)
                {
                    return NotFound();
                }
                CourseVM.Course = courseFromDb;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                CourseVM.Department = _deptRepo.GetDepartmentListOfDropDown();
                return Page();
            }
            if (CourseVM.Course.Id == 0)
            {
                _courseRepo.Add(CourseVM.Course);
            }
            else
            {
                _courseRepo.Update(CourseVM.Course);
            }
            _courseRepo.Save();
            return RedirectToPage("./Index");
        }
    }
}