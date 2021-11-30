using MediatR;

namespace MerchandiseService.Infrastructure.Commands.SetAwaitingDeliveryStatusCommand
{
    public class SetAwaitingDeliveryStatusCommand : IRequest
    {
        public SetAwaitingDeliveryStatusCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; private set; }
    }
}