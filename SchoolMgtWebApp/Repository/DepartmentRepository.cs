using Microsoft.EntityFrameworkCore;
using SchoolMgtWebApp.Data;
using SchoolMgtWebApp.Models;
using SchoolMgtWebApp.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Repository
{
    public class DepartmentRepository :IDepartment
    {
        private readonly ApplicationDbContext _db;
        public DepartmentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Department department)
        {
            _db.Department.Add(department);
        }

        public Department Get(int id)
        {
            return _db.Department.Find(id);
        }

        public IEnumerable<Department> GetAll(Expression<Func<Department, bool>> filter = null, Func<IQueryable<Department>, IOrderedQueryable<Department>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Department> query = _db.Department;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated.
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            return query.ToList();
        }

        public Department GetFisrtOrDefault(Expression<Func<Department, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Department> query = _db.Department;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            //include properties will be comma seperated.
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includeProperty);
                }
            }
            return query.FirstOrDefault();

        }

        public void Remove(Department department)
        {
            _db.Department.Remove(department);
        }

        public void Remove(int id)
        {
            var obj = _db.Department.Find(id);
            Remove(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Department department)
        {
            var objFromDb = _db.Department.FirstOrDefault(c => c.Id == department.Id);
            objFromDb.Name = department.Name;
            objFromDb.FacultyId = department.FacultyId;
        }
    }
}
