using Microsoft.AspNetCore.Mvc.Rendering;
using SchoolMgtWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Repository.IRepository
{
    public interface IDepartment
    {
        Department Get(int id);
        IEnumerable<Department> GetAll(
            Expression<Func<Department, bool>> filter = null,
            Func<IQueryable<Department>, IOrderedQueryable<Department>> orderBy = null,
            string includeProperties = null
            );
        Department GetFisrtOrDefault(
            Expression<Func<Department, bool>> filter = null,
            string includeProperties = null
            );
        void Add(Department department);
        void Remove(Department department);
        void Remove(int id);
        void Update(Department department);

        void Save();

        IEnumerable<SelectListItem> GetDepartmentListOfDropDown();


    }
}
