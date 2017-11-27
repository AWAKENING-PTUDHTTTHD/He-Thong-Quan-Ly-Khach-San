using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Management_Distributor.Dao.Interfaces;
using Management_Distributor.Dao._DbContext;
namespace Management_Distributor.Dao.Implementations
{
    public class GenericUnitOfWork : IUnitOfWork
    {
        private ManagementDistributorDbContext _context = null;
        public GenericUnitOfWork()
        {
            _context = new ManagementDistributorDbContext();
        }

        private Dictionary<Type, object> repositories = new Dictionary<Type, object>();

        public IRepository<T> Repository<T>() where T : class
        {
            IRepository<T> repo = null;
            if (repositories.ContainsKey(typeof(T)))
            {
                repo = repositories[typeof(T)] as IRepository<T>;
            }
            else
            {
                repo = new GenericRepository<T>(_context);
                repositories.Add(typeof(T), repo);
            }
            return repo;
        }

        public void SaveChange()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (disposed == false)
            {
                if (disposing == true)
                {
                    _context.Dispose();
                }
            }
            disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}