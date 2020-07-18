using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Models.ViewModal
{
    public class DeptViewModel
    {
        public Department Department { get; set; }

        public IEnumerable<SelectListItem> Faculty { get; set; }
    }
}
