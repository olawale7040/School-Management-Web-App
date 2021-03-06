﻿using System;
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
    public class CourseRegController : Controller
    {
        private readonly ICourse _courseRepo;
        public CourseRegController(ICourse courseRepo)
        {
            _courseRepo = courseRepo;
        }

        [HttpGet]
        public IActionResult GetAllCourses(int deptId)
        {
            var courses = _courseRepo.GetAll(c=>c.DeptId== deptId);
            return Json(new { data = courses });
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCourse(int id)
        {
            var courseFromDb = _courseRepo.GetFisrtOrDefault(c => c.Id == id);
            if (courseFromDb != null)
            {
                _courseRepo.Remove(courseFromDb);
                _courseRepo.Save();
                return Json(new { status = true, message = "Deleted Suucessfully" });
            }
            else
            {
                return Json(new { status = false, message = "Unable to delete" });
            }
        }
    }
}