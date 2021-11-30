using MerchService.Models;
using System.Threading;
using System.Threading.Tasks;

namespace MerchService.Services
{
    public interface IMerchandiseService
    {
        Task<long> GetMerchItems(GetMerchItemRequestModel merchItemRequest, CancellationToken token);
        Task<string> GetIssuingMerchInfo(long id, CancellationToken token);
    }
}