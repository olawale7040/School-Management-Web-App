using SchoolMgtWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Repository.IRepository
{
    public interface ICourse
    {
        Course Get(int id);
        IEnumerable<Course> GetAll(
            Expression<Func<Course, bool>> filter = null,
            Func<IQueryable<Course>, IOrderedQueryable<Course>> orderBy = null,
            string includeProperties = null
            );
        Course GetFisrtOrDefault(
            Expression<Func<Course, bool>> filter = null,
            string includeProperties = null
            );
        void Add(Course course);
        void Remove(Course course);
        void Remove(int id);
        void Update(Course course);

        void Save();

    }
}
