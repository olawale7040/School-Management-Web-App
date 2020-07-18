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
    public class ApplicationUserRepository : IApplicationUser
    {
        private readonly ApplicationDbContext _db;
        public ApplicationUserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        

        public ApplicationUser Get(int id)
        {
            return _db.ApplicationUser.Find(id);
        }

        public IEnumerable<ApplicationUser> GetAll(Expression<Func<ApplicationUser, bool>> filter = null, Func<IQueryable<ApplicationUser>, IOrderedQueryable<ApplicationUser>> orderBy = null, string includeProperties = null)
        {
            IQueryable<ApplicationUser> query = _db.ApplicationUser;
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

        public ApplicationUser GetFisrtOrDefault(Expression<Func<ApplicationUser, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<ApplicationUser> query = _db.ApplicationUser;
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

    }
}
