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
    public class FacultyController : Controller
    {
        private readonly IFaculty _facultyRepo;
        public FacultyController(IFaculty facultyRepo)
        {
            _facultyRepo = facultyRepo;
        }

        [HttpGet]
        public IActionResult GetAllCategory()
        {
            var faculties = _facultyRepo.GetAll();
            return Json(new { data = faculties });
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteFaculty(int id)
        {
            var facultyFromDb = _facultyRepo.GetFisrtOrDefault(c => c.Id == id);
            if (facultyFromDb != null)
            {
                _facultyRepo.Remove(facultyFromDb);
                _facultyRepo.Save();
                return Json(new { status = true, message = "Deleted Suucessfully" });
            }
            else
            {
                return Json(new { status = false, message = "Unable to delete" });
            }
        }
    }
}