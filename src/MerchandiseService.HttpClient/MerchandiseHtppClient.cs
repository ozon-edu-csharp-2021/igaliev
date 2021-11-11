using MerchandiseService.HttpClient.Interfaces;
using MerchandiseService.HttpModels;
using System.Collections.Generic;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;


namespace MerchandiseService.HttpClient
{
    public class MerchandiseHtppClient:IMerchandiseHttpClient
    {
        private readonly System.Net.Http.HttpClient _httpClient;

        public MerchandiseHtppClient(System.Net.Http.HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<MerchItemResponse>> GetAllMerchItems(CancellationToken token)
        {
            using var response = await _httpClient.GetAsync("v1/api/merchandise", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<List<MerchItemResponse>>(body);
        }

        public async Task<MerchItemResponse> GetMerchItemById(long id, CancellationToken token)
        {
            using var response = await _httpClient.GetAsync($"v1/api/merchandise/{id}", token);
            var body = await response.Content.ReadAsStringAsync(token);
            return JsonSerializer.Deserialize<MerchItemResponse>(body);
        }
    }
}