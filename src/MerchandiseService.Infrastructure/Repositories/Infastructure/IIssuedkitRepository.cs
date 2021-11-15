using MerchandiseService.Infrastructure.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Repositories.Infastructure
{
   public  interface IIssuedKitRepository
    {
      Task<KitIssuedDto> CheckIsKitIssuied(int employeeId, int merchKitId,CancellationToken cancelletionToken);
    }
}
