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
    public class StudentRepository : IStudent
    {
        private readonly ApplicationDbContext _db;
        public StudentRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Student student)
        {
            _db.Student.Add(student);
        }

        public Student Get(int id)
        {
            return _db.Student.Find(id);
        }

        public IEnumerable<Student> GetAll(Expression<Func<Student, bool>> filter = null, Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Student> query = _db.Student;
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

        public Student GetFisrtOrDefault(Expression<Func<Student, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Student> query = _db.Student;
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

        public void Remove(Student student)
        {
            _db.Student.Remove(student);
        }

        public void Remove(int id)
        {
            var obj = _db.Student.Find(id);
            Remove(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Student student)
        {
            var objFromDb = _db.Student.FirstOrDefault(c => c.Id == student.Id);
            objFromDb.FirstName = student.FirstName;
        }
    }
}
