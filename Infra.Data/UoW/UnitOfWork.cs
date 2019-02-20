using System;
using System.Threading.Tasks;
using Framework.Core.Interfaces;
using Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infra.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContextGeneric _context;

        public UnitOfWork(DbContextGeneric context)
        {
            _context = context;
        }

        public async Task<bool> CommitAsync()
        {
            try
            {
                var nSaved = _context.SaveChanges();
                return nSaved > 0;
            }
            catch (DbUpdateException e)
            {
                throw new Exception(e.Message); //couldn’t handle that error, so rethrow
            }

           
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
