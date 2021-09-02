using System;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IOwnerRepository Owners { get; }
        IAccountRepository Accounts { get; }
        //void Save();
        Task SaveAsync();
    }
}