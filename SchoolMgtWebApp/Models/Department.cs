using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Models
{
    public class Department
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Display(Name="Faculty")]
        public int FacultyId { get; set; }


        [ForeignKey("FacultyId")]
        public virtual Faculty Faculty { get; set; }
    }
}
