
using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;

namespace MerchandiseService.Domain.Events
{
    class MerchOrderCancelledDomainEvent : INotification
    {
        public MerchOrderCancelledDomainEvent(MerchOrder order)
        {
            Order = order;
        }

        public MerchOrder Order { get; }
    }
}