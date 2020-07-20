using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SchoolMgtWebApp.Models;

namespace SchoolMgtWebApp.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

         }
        public DbSet<Faculty> Faculty { get; set; }

        public DbSet<Department> Department { get; set; }

        public DbSet<Course> Course { get; set; }


        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        public DbSet<Student> Student { get; set; }



        public DbSet<CourseRegistered> CourseRegistered { get; set; }





    }
}
