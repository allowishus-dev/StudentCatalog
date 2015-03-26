using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudentCatalogFresh.Models;

namespace StudentCatalogFresh.Abstract
{
    public interface IStudentRepository
    {
        IQueryable<Student> All { get; }

        IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties);

        Student Find(int id);

        void Delete(int id);

        void Save();

        void InsertOrUpdate(Student student);
    }
}
