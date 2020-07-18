using SchoolMgtWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Repository.IRepository
{
    public interface IApplicationUser
    {
        ApplicationUser Get(int id);
        IEnumerable<ApplicationUser> GetAll(
            Expression<Func<ApplicationUser, bool>> filter = null,
            Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null,
            string includeProperties = null
            );
        ApplicationUser GetFisrtOrDefault(
            Expression<Func<ApplicationUser, bool>> filter = null,
            string includeProperties = null
            );

    }
}
