using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management_Distributor.Dao.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        // Repository equivalent DbSet
        IRepository<T> Repository<T>() where T : class;
        int SaveChange();
        void Dispose(bool disposing);
        new void Dispose();
    }
}
