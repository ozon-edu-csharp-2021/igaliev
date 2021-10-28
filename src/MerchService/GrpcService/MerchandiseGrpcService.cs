using System.Threading.Tasks;
using Grpc.Core;
using MerchandiseService.Grpc;
using MerchService.Models;
using MerchService.Services;


namespace MerchService.GrpcService
{
    public class MerchandiseGrpcService: MerchandiseGrpc.MerchandiseGrpcBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseGrpcService(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        public override async Task<GetMerchItemsResponse> GetMerchItems(GetMerchItemsRequest request, ServerCallContext context)
        {
            var merchItemReqeustModel = new GetMerchItemRequestModel(request.MerchItemId, request.EmployeeId, request.Status);
            var requestId = await _merchandiseService.GetMerchItems(merchItemReqeustModel, new System.Threading.CancellationToken());
            return new GetMerchItemsResponse() {
                RequestId = requestId
            };

        }

        public override async Task<GetIssuingMerchInfoResponse> GetIssuingMerchInfo(GetIssuingMerchInfoRequest request, ServerCallContext context)
        {
            var merchInfoId = request.GetMerchItemRequestId;
            var status =await  _merchandiseService.GetIssuingMerchInfo(merchInfoId, new System.Threading.CancellationToken());

            return new GetIssuingMerchInfoResponse()
            {
                Status = status
            };
           
        }
    }
}