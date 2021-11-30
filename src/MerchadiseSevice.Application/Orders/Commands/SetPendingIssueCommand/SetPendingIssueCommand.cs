using MediatR;

namespace MerchandiseService.Infrastructure.Commands.SetPendingIssueCommand
{
    public class SetPendingIssueCommand : IRequest
    {
        public SetPendingIssueCommand(int orderId)
        {
            OrderId = orderId;
        }

        public int OrderId { get; set; }
    }
}