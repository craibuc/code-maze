using Domain.Interfaces;
using Repository.Repositories;
using System;
using System.Threading.Tasks;

namespace Repository
{
    public class UnitOfWork: IUnitOfWork
    {
        private readonly RepositoryContext _context;

        public IOwnerRepository Owners { get; private set; }
        public IAccountRepository Accounts { get; private set; }

        public UnitOfWork(RepositoryContext repositoryContext)
        {
            _context = repositoryContext;

            Owners = new OwnerRepository(_context);
            Accounts = new AccountRepository(_context);
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}