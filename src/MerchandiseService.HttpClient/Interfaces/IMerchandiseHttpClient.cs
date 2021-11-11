using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.HttpModels;

namespace MerchandiseService.HttpClient.Interfaces
{
    public interface IMerchandiseHttpClient
    {
        Task<List<MerchItemResponse>> GetAllMerchItems(CancellationToken token);

        Task<MerchItemResponse> GetMerchItemById(long id, CancellationToken token);
    }
}