using MediatR;
using MerchandiseService.Domain.Events;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Handlers.DomainEventHandlers
{
    public class MerchOrderAwaitingVerificationDomainEventHandler : INotificationHandler<MerchOrderAwaitingVerificationDomainEvent>
    {
        public Task Handle(MerchOrderAwaitingVerificationDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}