using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Models
{
    public class Student
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Matric No")]
        public int MatricNo { get; set; }

        [Required]
        [Display(Name="First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Department")]
        public int DeptId { get; set; }
        
        [ForeignKey("DeptId")]
        public virtual Department Department { get; set; }

        [Required]
        public string Level { get; set; }

        public String ApplicationUserId { get; set; }

        [NotMapped]
        [ForeignKey("ApplicationUserId")]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
