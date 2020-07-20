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
    public class StudentController : Controller
    {
        private readonly IDepartment _departmentRepo;
        private readonly IStudent _studnetRepo;
        public StudentController(IDepartment departmentRepo, IStudent studnetRepo)
        {
            _departmentRepo = departmentRepo;
            _studnetRepo = studnetRepo;
        }

        [HttpGet]
        public IActionResult GetAllDepartment()
        {
            var students = _studnetRepo.GetAll(null,null,"Department");
            return Json(new { data = students });
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteStudent(int id)
        {
            var studentFromDb = _studnetRepo.GetFisrtOrDefault(c => c.Id == id);
            if (studentFromDb != null)
            {
                _studnetRepo.Remove(studentFromDb);
                _studnetRepo.Save();
                return Json(new { status = true, message = "Deleted Suucessfully" });
            }
            else
            {
                return Json(new { status = false, message = "Unable to delete" });
            }
        }
    }
}