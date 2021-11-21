using System;
using System.Threading;
using System.Threading.Tasks;
using MerchadiseSevice.Application.Orders.Queries.CheckIsMerchIssuedQuery;

namespace MerchadiseSevice.Application.Interfaces
{
    public interface IIssuedKitRepository
    {
        public async Task<KitIssuedDto> CheckIsKitIssuied(int employeeId, int merchKitId, CancellationToken cancellationToken)
        {
            //TODO : дожен возращать выдавался ли тот или иной комплект
            throw new NotImplementedException();
        }
    }
}