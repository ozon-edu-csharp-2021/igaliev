using MediatR;
using MerchandiseService.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Handlers.DomainEventHandlers
{
    public class MerchOrderCompletedDomainEventHandler : INotificationHandler<MerchOrderCompletedDomainEvent>
    {
        public Task Handle(MerchOrderCompletedDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}