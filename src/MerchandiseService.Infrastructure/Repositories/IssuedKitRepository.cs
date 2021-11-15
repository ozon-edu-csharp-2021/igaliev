using MerchandiseService.Infrastructure.Repositories.Infastructure;
using MerchandiseService.Infrastructure.Repositories.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories
{
    class IssuedKitRepository : IIssuedKitRepository
    {
        public async Task<KitIssuedDto> CheckIsKitIssuied(int employeeId, int merchKitId, CancellationToken cancellationToken)
        {
            //TODO : дожен возращать выдавался ли тот или иной комплект
            throw new NotImplementedException();
        }
    }
}
