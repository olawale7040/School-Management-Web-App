using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolMgtWebApp.Repository.IRepository;

namespace SchoolMgtWebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : Controller
    {
        private readonly IDepartment _departmentRepo;
        public DepartmentController(IDepartment departmentRepo)
        {
            _departmentRepo = departmentRepo;
        }

        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            var depts = _departmentRepo.GetAll(null,null,"Faculty");
            return Json(new { data = depts });
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteDepartment(int id)
        {
            var deptFromDb = _departmentRepo.GetFisrtOrDefault(c => c.Id == id);
            if (deptFromDb != null)
            {
                _departmentRepo.Remove(deptFromDb);
                _departmentRepo.Save();
                return Json(new { status = true, message = "Deleted Suucessfully" });
            }
            else
            {
                return Json(new { status = false, message = "Unable to delete" });
            }
        }
    }
}