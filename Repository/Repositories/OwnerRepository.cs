using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;

namespace Repository.Repositories
{
    public class OwnerRepository : GenericRepository<Owner>, IOwnerRepository
    {
        public OwnerRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        //public async Task<IEnumerable<Owner>> GetAllOwners()
        //{
        //    return await GetAsync()
        //        .OrderBy(ow => ow.Name)
        //        .ToList();
        //}
    }
}