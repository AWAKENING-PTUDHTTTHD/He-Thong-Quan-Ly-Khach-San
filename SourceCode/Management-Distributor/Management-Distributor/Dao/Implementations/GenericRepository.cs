using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Management_Distributor.Dao.Interfaces;
using Management_Distributor.Dao._DbContext;

namespace Management_Distributor.Dao.Implementations
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {
        private ManagementDistributorDbContext _context;
        public GenericRepository(ManagementDistributorDbContext context)
        {
            _context = context;
        }
        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Attach(T entity)
        {
            _context.Set<T>().Attach(entity);
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

        public T GetById(string id)
        {
            return _context.Set<T>().Find(id);
        }
    }
}