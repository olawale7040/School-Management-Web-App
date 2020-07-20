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
    public class CourseRegisteredRepo : ICourseRegistered
    {
        private readonly ApplicationDbContext _db;
        public CourseRegisteredRepo(ApplicationDbContext db)
        {
            _db = db;
        }
        public void Add(CourseRegistered coureReg)
        {
            _db.CourseRegistered.Add(coureReg);
        }

        public CourseRegistered Get(int id)
        {
            return _db.CourseRegistered.Find(id);
        }

        public IEnumerable<CourseRegistered> GetAll(Expression<Func<CourseRegistered, bool>> filter = null, Func<IQueryable<CourseRegistered>, IOrderedQueryable<CourseRegistered>> orderBy = null, string includeProperties = null)
        {
            IQueryable<CourseRegistered> query = _db.CourseRegistered;
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

        public CourseRegistered GetFisrtOrDefault(Expression<Func<CourseRegistered, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<CourseRegistered> query = _db.CourseRegistered;
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

        public void Remove(CourseRegistered removeCourse)
        {
            _db.CourseRegistered.Remove(removeCourse);
        }

        public void Remove(int id)
        {
            var obj = _db.CourseRegistered.Find(id);
            Remove(obj);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

    }
}
