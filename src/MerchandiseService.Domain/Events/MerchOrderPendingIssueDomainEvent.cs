
using MediatR;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderPendingIssueDomainEvent : INotification
    {
        public MerchOrderPendingIssueDomainEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }
    }
}
