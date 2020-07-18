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
    public class CourseRepository : ICourse
    {
        private readonly ApplicationDbContext _db;
        public CourseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(Course course)
        {
            _db.Course.Add(course);
        }

        public Course Get(int id)
        {
            return _db.Course.Find(id);
        }

        public IEnumerable<Course> GetAll(Expression<Func<Course, bool>> filter = null, Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Course> query = _db.Course;
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

        public Course GetFisrtOrDefault(Expression<Func<Course, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Course> query = _db.Course;
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

        public void Remove(Course course)
        {
            _db.Course.Remove(course);
        }

        public void Remove(int id)
        {
            var obj = _db.Course.Find(id);
            Remove(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Course course)
        {
            var objFromDb = _db.Course.FirstOrDefault(c => c.Id == course.Id);
            objFromDb.CourseTitle = course.CourseTitle;
            objFromDb.CourseCode = course.CourseCode;
            objFromDb.CourseUnit = course.CourseUnit;
            objFromDb.DeptId = course.DeptId;
            objFromDb.Semester = course.Semester;

        }
    }
}
