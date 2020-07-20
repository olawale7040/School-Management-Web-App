using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Utilitis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Data.initializer
{
    public class DbInitializer : IDbInitiazer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _db = db;
            _roleManager = roleManager;

        }
        public void Initizer()
        {
            try
            {
                if (_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
            if (_db.Roles.Any(r => r.Name == SD.AdminRole)) return;
            _roleManager.CreateAsync(new IdentityRole(SD.AdminRole)).GetAwaiter().GetResult();
            _roleManager.CreateAsync(new IdentityRole(SD.StudentRole)).GetAwaiter().GetResult();
            

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "olawale7040@gmail.com",
                Email = "olawale7040@gmail.com",
                EmailConfirmed = true,
                FirstName = "Adekunle",
                LastName = "Nasman",
            }, "Admin123*").GetAwaiter().GetResult();

            var user = _db.ApplicationUser.Where(u => u.Email == "olawale7040@gmail.com").FirstOrDefault();
            _userManager.AddToRoleAsync(user, SD.AdminRole).GetAwaiter().GetResult();

        }
    }
}
