
using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;

namespace MerchandiseService.Domain.Events
{
    public class MerchOrderCompletedDomainEvent : INotification
    {
        public MerchOrderCompletedDomainEvent(MerchOrder order)
        {
            Order = order;
        }

        public MerchOrder Order { get; }
    }
}
