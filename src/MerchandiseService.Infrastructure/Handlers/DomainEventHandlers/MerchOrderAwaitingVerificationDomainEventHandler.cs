using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEventHandlers
{
    public class MerchOrderAwaitingVerificationDomainEventHandler:INotificationHandler<MerchOrderAwaitingVerificationDomainEvent>
    {
        public Task Handle(MerchOrderAwaitingVerificationDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}