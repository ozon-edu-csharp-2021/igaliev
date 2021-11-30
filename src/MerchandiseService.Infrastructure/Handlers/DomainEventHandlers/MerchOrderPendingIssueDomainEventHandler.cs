using MediatR;
using MerchandiseService.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Handlers.DomainEventHandlers
{
    public class MerchOrderPendingIssueDomainEventHandler : INotificationHandler<MerchOrderPendingIssueDomainEvent>
    {
        public Task Handle(MerchOrderPendingIssueDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}