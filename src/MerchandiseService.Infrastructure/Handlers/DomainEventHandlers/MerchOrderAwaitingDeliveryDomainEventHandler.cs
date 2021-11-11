using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.Events;

namespace MerchandiseService.Infrastructure.Handlers.DomainEventHandlers
{
    public class MerchOrderAwaitingDeliveryDomainEventHandler:INotificationHandler<MerchOrderAwaitingDeliveryDomainEvent>
    {
        //TODO:
        public Task Handle(MerchOrderAwaitingDeliveryDomainEvent notification, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}