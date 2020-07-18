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
    public class FacultyRepository : IFaculty
    {
        private readonly ApplicationDbContext _db;
        public FacultyRepository(ApplicationDbContext db)
        {
            _db = db;    
        }
        public void Add(Faculty faculty)
        {
            _db.Faculty.Add(faculty);
        }

        public Faculty Get(int id)
        {
            return _db.Faculty.Find(id);
        }

        public IEnumerable<Faculty> GetAll(Expression<Func<Faculty, bool>> filter = null, Func<IQueryable<Faculty>, IOrderedQueryable<Faculty>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Faculty> query = _db.Faculty;
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

        public Faculty GetFisrtOrDefault(Expression<Func<Faculty, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Faculty> query = _db.Faculty;
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

        public void Remove(Faculty faculty)
        {
            _db.Faculty.Remove(faculty);
        }

        public void Remove(int id)
        {
            var obj = _db.Faculty.Find(id);
            Remove(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Faculty faculty)
        {
            var objFromDb = _db.Faculty.FirstOrDefault(c => c.Id == faculty.Id);
            objFromDb.Name = faculty.Name;
        }
    }
}
