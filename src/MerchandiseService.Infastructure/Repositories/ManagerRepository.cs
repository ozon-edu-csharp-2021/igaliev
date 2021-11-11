using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.ManagerAggregation;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infastructure.Repositories
{
    public class ManagerRepository : IManagerRepository


    {
        public Task<Manager> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<Manager> FindByEmailAsync(string email, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<ICollection<Manager>> GetAllEmployees(CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}