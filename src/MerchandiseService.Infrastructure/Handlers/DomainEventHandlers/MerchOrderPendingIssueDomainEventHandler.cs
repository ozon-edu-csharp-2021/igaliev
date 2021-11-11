using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEventHandlers
{
    public class MerchOrderPendingIssueDomainEventHandler:INotificationHandler<MerchOrderPendingIssueDomainEvent>
    {
        public Task Handle(MerchOrderPendingIssueDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}