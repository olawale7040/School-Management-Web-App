using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Models
{
    public class CourseRegistered
    {
        public int Id { get; set; }

        [Display(Name = "Student")]
        public int StudentId { get; set; }

        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }

        [Display(Name = "Course")]
        public int CourseId { get; set; }

       // [ForeignKey("CourseId")]
       // public virtual Course Course { get; set; }

        public string Level { get; set; }

        public string Session { get; set; }

        public DateTime DateRegistered { get; set; }
    }
}
