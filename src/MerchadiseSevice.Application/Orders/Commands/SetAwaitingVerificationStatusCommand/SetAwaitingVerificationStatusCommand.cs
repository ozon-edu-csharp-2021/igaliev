using MediatR;

namespace MerchandiseService.Infrastructure.Commands.SetAwaitingVerificationStatusCommand
{
    public class SetAwaitingVerificationStatusCommand : IRequest
    {
        public SetAwaitingVerificationStatusCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }
    }
}