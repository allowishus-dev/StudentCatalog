using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using StudentCatalogFresh.Abstract;
using StudentCatalogFresh.Models;

namespace StudentCatalogFresh.Repository
{
    public class CompetencyHeaderRepository : ICompetencyHeaderRepository
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<CompetencyHeader> All
        {
            get { return db.CompetencyHeaders; }
        }

        public IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties)
        {
            IQueryable<CompetencyHeader> query = db.CompetencyHeaders;
            foreach (var includeProperty in includeProperties)
            {
                query = query.Include(includeProperty);
            }
            return query;
        }

        public CompetencyHeader Find(int id)
        {
            return db.CompetencyHeaders.Find(id);
        }

        public void Delete(int id)
        {
            CompetencyHeader competencyHeader = db.CompetencyHeaders.Find(id);
            db.CompetencyHeaders.Remove(competencyHeader);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void InsertOrUpdate(CompetencyHeader competencyHeader)
        {
            if (competencyHeader.CompetencyHeaderId == default(int))
            {
                db.CompetencyHeaders.Add(competencyHeader);
            }
            else
            {
                db.Entry(competencyHeader).State = EntityState.Modified;
            }
        }
    }
}