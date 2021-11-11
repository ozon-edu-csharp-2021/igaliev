using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infastructure.Repositories
{
    public class MerchOrderRepository : IMerchOrderRepository
    {
        public IUnitOfWork UnitOfWork { get; }
        public Task<MerchOrder> FindByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<MerchOrder>> FindByEmployeeIdAsync(long id, CancellationToken cancellationToken = default)
        {
            throw new System.NotImplementedException();
        }
    }
}