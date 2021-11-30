using MediatR;

namespace MerchandiseService.Infrastructure.Commands.SetOrderCompletedStatusCommand
{
    public class SetOrderCompletedStatusCommand : IRequest
    {
        public SetOrderCompletedStatusCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }
    }
}