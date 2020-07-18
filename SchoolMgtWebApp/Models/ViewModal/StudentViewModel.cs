using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Models.ViewModal
{
    public class StudentViewModel
    {
       
        public Student Student { get; set; }

        public IEnumerable<SelectListItem> Department { get; set; }


    }
}
