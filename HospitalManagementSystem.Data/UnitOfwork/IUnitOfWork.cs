using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.UnitOfwork
{
    public interface IUnitOfWork : IDisposable
    {
        Task<int> SaveChangesAsync(); // Returns the number of records it affects as a number.

        Task BeginTransaction();

        Task CommitTransaction();

        Task RollBackTransaction();

    }
}
