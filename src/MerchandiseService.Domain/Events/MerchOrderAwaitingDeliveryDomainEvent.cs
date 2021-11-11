using MediatR;


namespace MerchandiseService.Domain.Events
{
    public class MerchOrderAwaitingDeliveryDomainEvent : INotification
    {
        public MerchOrderAwaitingDeliveryDomainEvent(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; }

    }
}
