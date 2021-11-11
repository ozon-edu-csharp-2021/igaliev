using MediatR;

namespace MerchandiseService.Infastructure.Commands.SendMerchOrderToQueue
{
    public class SendMerchOrderToQueueCommand : IRequest<int>
    {
        public long MerchOderId { get; set; }
    }
}