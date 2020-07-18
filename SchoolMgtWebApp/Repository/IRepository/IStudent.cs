using SchoolMgtWebApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace SchoolMgtWebApp.Repository.IRepository
{
    public interface IStudent
    {
        Student Get(int id);
        IEnumerable<Student> GetAll(
            Expression<Func<Student, bool>> filter = null,
            Func<IQueryable<Student>, IOrderedQueryable<Student>> orderBy = null,
            string includeProperties = null
            );
        Student GetFisrtOrDefault(
            Expression<Func<Student, bool>> filter = null,
            string includeProperties = null
            );
        void Add(Student student);
        void Remove(Student student);
        void Remove(int id);
        void Update(Student student);

        void Save();

    }
}
