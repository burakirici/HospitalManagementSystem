using HospitalManagementSystem.Data.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalManagementSystem.Data.UnitOfwork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly HospitalManagementSystemDbContext _context;
        private IDbContextTransaction _transaction;

        public UnitOfWork(HospitalManagementSystemDbContext context)
        {
            _context = context;
        }
        public async Task BeginTransaction()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransaction()
        {
            await _transaction.CommitAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task RollBackTransaction()
        {
            await _transaction.RollbackAsync();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
