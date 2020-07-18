using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Models.ViewModal;
using SchoolMgtWebApp.Repository.IRepository;

namespace SchoolMgtWebApp.Pages.Admin.Departments
{
    public class UpSertModel : PageModel
    {
        private IDepartment _deptRepo;
        private IFaculty _facultyRepo;
        public UpSertModel(IDepartment deptRepo, IFaculty facultyRepo)
        {
            _deptRepo = deptRepo;
            _facultyRepo = facultyRepo;
        }

        [BindProperty]
        public DeptViewModel DepartmentVM { get; set; }
        public IActionResult OnGet(int? id)
        {
            DepartmentVM = new DeptViewModel()
            {
                Faculty = _facultyRepo.GetFacultyListOfDropDown(),
                Department = new Department()
            };
            if (id != null)
            {
                var deptFromDb = _deptRepo.GetFisrtOrDefault(m => m.Id == id);
                if (deptFromDb == null)
                {
                    return NotFound();
                }
                DepartmentVM.Department = deptFromDb;
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                DepartmentVM.Faculty = _facultyRepo.GetFacultyListOfDropDown();
                return Page();
            }
            if (DepartmentVM.Department.Id == 0)
            {
                _deptRepo.Add(DepartmentVM.Department);
            }
            else
            {
                _deptRepo.Update(DepartmentVM.Department);
            }
            _deptRepo.Save();
            return RedirectToPage("./Index");
        }
    }
}