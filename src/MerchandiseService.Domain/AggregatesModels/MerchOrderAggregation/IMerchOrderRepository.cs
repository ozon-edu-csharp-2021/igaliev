using MerchandiseService.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public interface IMerchOrderRepository : IRepository<MerchOrder>
    {
        Task<MerchOrder> FindByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<List<MerchOrder>> FindByEmployeeIdAsync(long id, CancellationToken cancellationToken = default);
    }
}