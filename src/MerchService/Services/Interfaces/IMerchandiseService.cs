using System.Threading;
using System.Threading.Tasks;
using MerchService.Models;

namespace MerchService.Services
{
    public interface IMerchandiseService
    {
        Task<long> GetMerchItems(GetMerchItemRequestModel merchItemRequest, CancellationToken token);
        Task<string> GetIssuingMerchInfo(long id, CancellationToken token);
    }
}