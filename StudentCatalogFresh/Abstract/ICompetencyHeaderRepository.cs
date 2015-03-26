using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using StudentCatalogFresh.Models;

namespace StudentCatalogFresh.Abstract
{
    public interface ICompetencyHeaderRepository
    {
        IQueryable<CompetencyHeader> All { get; }

        IQueryable<CompetencyHeader> AllIncluding(params Expression<Func<CompetencyHeader, object>>[] includeProperties);

        CompetencyHeader Find(int id);

        void Delete(int id);

        void Save();

        void InsertOrUpdate(CompetencyHeader competencyHeader);
    }
}