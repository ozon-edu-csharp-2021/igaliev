using MediatR;

namespace MerchandiseService.Infrastructure.Commands.SetOrderCancelledStatusCommand
{
    public class SetOrderCancelledStatusCommand:IRequest
    {
        public SetOrderCancelledStatusCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }
    }
}