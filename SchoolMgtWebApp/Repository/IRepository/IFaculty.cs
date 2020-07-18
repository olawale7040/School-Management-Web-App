using SchoolMgtWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Repository.IRepository
{
    public interface IFaculty
    {
        Faculty Get(int id);
        IEnumerable<Faculty> GetAll(
            Expression<Func<Faculty, bool>> filter = null,
            Func<IQueryable<Faculty>, IOrderedQueryable<Faculty>> orderBy = null,
            string includeProperties = null
            );
        Faculty GetFisrtOrDefault(
            Expression<Func<Faculty, bool>> filter = null,
            string includeProperties = null
            );
        void Add(Faculty faculty);
        void Remove(Faculty faculty);

        void Remove(int id);
        void Update(Faculty faculty);

        void Save();

    }
}
