using SchoolMgtWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Repository.IRepository
{
    public interface ICourseRegistered
    {
        CourseRegistered Get(int id);
        IEnumerable<CourseRegistered> GetAll(
            Expression<Func<CourseRegistered, bool>> filter = null,
            Func<IQueryable<CourseRegistered>, IOrderedQueryable<CourseRegistered>> orderBy = null,
            string includeProperties = null
            );
        CourseRegistered GetFisrtOrDefault(
            Expression<Func<CourseRegistered, bool>> filter = null,
            string includeProperties = null
            );
        void Add(CourseRegistered CourseRegistered);
        void Remove(CourseRegistered CourseRegistered);
        void Remove(int id);

        void Save();

    }
}
