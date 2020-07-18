using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Models
{
    public class Course
    {
        public int Id { get; set; }

        [Required]
        [Display(Name="Course Title")]
        public string CourseTitle { get; set; }

        [Required]
        [Display(Name = "Course Code")]
        public string CourseCode { get; set; }

        public string Semester { get; set; }

        [Required]
        [Display(Name = "Course Unit")]
        public int CourseUnit { get; set; }


        [Display(Name = "Department")]
        public int DeptId { get; set; }


        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }
    }
}
