using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Repository.IRepository;
using SchoolMgtWebApp.Utilitis;

namespace SchoolMgtWebApp.Pages.Admin.Faculties
{
    [Authorize(Roles = SD.AdminRole)]
    public class UpSertModel : PageModel
    {
        private readonly IFaculty _facultyRepo;


        public UpSertModel(IFaculty facultyRepo)
        {
            _facultyRepo = facultyRepo;
        }

        [BindProperty]
        public Faculty CreateObj { get; set; }
        public IActionResult OnGet(int? id)
        {
            CreateObj = new Faculty();
            if (id != null)
            {
                CreateObj = _facultyRepo.GetFisrtOrDefault(c => c.Id == id.GetValueOrDefault());
                if (CreateObj == null)
                {
                    return NotFound();
                }
            }
            return Page();
        }
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            else
            {
                if (CreateObj.Id != 0)
                {
                    _facultyRepo.Update(CreateObj);
                }
                else
                {
                    _facultyRepo.Add(CreateObj);
                }
                _facultyRepo.Save();
                return RedirectToPage("./Index");
            }
        }
        
    }
}