using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;

namespace Dal
{
    /// <summary>
    /// The EF-dependent, generic repository for data access
    /// </summary>    
    /// <typeparam name="TC">DB context</typeparam>
    public class EFRepository<TC> : IDisposable, IRepository where TC : DbContext
    {
        public TC DataContext { set; get; }


        public virtual IQueryable<TE> GetQuery<TE>() where TE : class
        {
            var query = DataContext.Set<TE>();
            return query;

        }

        public IQueryable<TE> GetQuery<TE>(IEnumerable<string> includes) where TE : class
        {
            var query = DataContext.Set<TE>().AsQueryable();
            includes.ToList().ForEach(i => query = query.Include(i));
            return query;
        }

        public IEnumerable<TE> GetList<TE>() where TE : class
        {
            return GetQuery<TE>().ToList();
        }

        public void Add<TE>(TE entity) where TE : class
        {
            DataContext.Set<TE>().Add(entity);
        }

        public void Attach<TE>(TE entity) where TE : class
        {
            DataContext.Set<TE>().Attach(entity);
        }

        public void Delete<TE>(TE entity) where TE : class
        {
            DataContext.Set<TE>().Remove(entity);
        }

        public void Commit()
        {
            DataContext.SaveChanges();
        }

        public void Dispose()
        {
            if (DataContext != null)
                DataContext.Dispose();
        }
    }


    public interface IRepository
    {
        IQueryable<TE> GetQuery<TE>() where TE : class;
        IQueryable<TE> GetQuery<TE>(IEnumerable<string> includes) where TE : class;
        IEnumerable<TE> GetList<TE>() where TE : class;
        void Add<TE>(TE entity) where TE : class;
        void Attach<TE>(TE entity) where TE : class;
        void Delete<TE>(TE entity) where TE : class;
        void Commit();
    }
}
