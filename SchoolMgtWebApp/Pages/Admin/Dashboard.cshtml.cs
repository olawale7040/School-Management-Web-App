using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models.ViewModal;
using SchoolMgtWebApp.Repository.IRepository;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages.Admin
{
    [Authorize(Roles = SD.AdminRole)]
    public class DashboardModel : PageModel
    {
        private IDepartment _deptRepo;
        private ICourse _courseRepo;
        private IFaculty _facultyRepo;
        private IStudent _studentRepo;

        public DashboardModel(IDepartment deptRepo,
            ICourse courseRepo,
            IFaculty facultyRepo,
            IStudent studentRepo
            )
        {
            _deptRepo = deptRepo;
            _courseRepo = courseRepo;
            _facultyRepo = facultyRepo;
            _studentRepo = studentRepo;
        }

        [BindProperty]
        public AdminViewModel AdminVM { get; set; }
        public void OnGet()
        {
            AdminVM = new AdminViewModel
            {
                NoOfCourses = _courseRepo.GetAll().ToList().Count,
                NoOfDepts = _deptRepo.GetAll().ToList().Count,
                NoOfFaculties = _facultyRepo.GetAll().Count(),
                NoOfStudents = _studentRepo.GetAll().Count(),
            };
        }
    }
}