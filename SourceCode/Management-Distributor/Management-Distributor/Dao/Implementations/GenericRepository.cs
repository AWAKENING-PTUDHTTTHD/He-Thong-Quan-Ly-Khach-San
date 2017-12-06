using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Management_Distributor.Dao.Interfaces;
using Management_Distributor.Dao._DbContext;

namespace Management_Distributor.Dao.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        //protected readonly DbContext _context;
        private readonly DbContext _context;
        public GenericRepository(DbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            if(entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _context.Set<T>().Add(entity);
        }

        public void AddRange(IEnumerable<T> entity)
        {
            _context.Set<T>().AddRange(entity);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public T Get(Func<T, bool> predicate)
        {
            return _context.Set<T>().First(predicate);
        }

        public IEnumerable<T> GetAll(Func<T, bool> predicate = null)
        {
            if (predicate != null)
            {
                return _context.Set<T>().Where(predicate);
            }
            return _context.Set<T>().AsEnumerable<T>();
        }

        public T GetById(object id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}