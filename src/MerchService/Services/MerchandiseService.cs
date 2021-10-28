using System;
using System.Threading;
using System.Threading.Tasks;

using MerchService.Models;

namespace MerchService.Services
{
    public class MerchandiseService : IMerchandiseService
    {
       
        public Task<long> GetMerchItems(GetMerchItemRequestModel merchItemRequest, CancellationToken token)
        {
            throw new NotImplementedException();
        }

        Task<string> IMerchandiseService.GetIssuingMerchInfo(long id, CancellationToken token)
        {
            throw new NotImplementedException();
        }
    }
}