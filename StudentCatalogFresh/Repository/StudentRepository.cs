using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Management;
using Microsoft.Ajax.Utilities;
using StudentCatalogFresh.Abstract;
using StudentCatalogFresh.Models;

namespace StudentCatalogFresh.Repository
{
    public class StudentRepository : IStudentRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Student> All
        {
            get { return db.Students; }
        }

        public IQueryable<Student> AllIncluding(params Expression<Func<Student, object>>[] includeProperties)
        {
            IQueryable<Student> query = db.Students;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public Student Find(int id)
        {
            return db.Students.Find(id);
        }

        public void Delete(int id)
        {
            Student student = db.Students.Find(id);
            db.Students.Remove(student);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void InsertOrUpdate(Student student)
        {
            if (student.StudentId == default(int))
            {
                db.Students.Add(student);
            }
            else
            {
                db.Entry(student).State = EntityState.Modified;
            }
        }
    }
}