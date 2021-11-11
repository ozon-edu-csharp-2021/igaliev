
using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderAwaitingVerificationDomainEvent : INotification
    {
        public MerchOrderAwaitingVerificationDomainEvent(int orderId, MerchKit merchKit)
        {
            OrderId = orderId;
            MerchKit = merchKit;
        }

        public int OrderId { get; }
        public MerchKit MerchKit { get; }
    }
}
