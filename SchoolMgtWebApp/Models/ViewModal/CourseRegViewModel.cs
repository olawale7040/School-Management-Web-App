using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Models.ViewModal
{
    public class CourseRegViewModel
    {
        public ICollection<Course> AllCourses { get; set; }

        public ICollection<CourseRegistered> RegisteredCourses { get; set; }

        public Student StudentInfo { get; set; }

    }
}
