using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Commands.SetPendingIssueCommand
{
    public class SetPendingIssueCommandHandler : IRequestHandler<SetPendingIssueCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public SetPendingIssueCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<Unit> Handle(SetPendingIssueCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            merchOrder.SetPendingIssueStatus();
            await _merchOrderRepository.UpdateAsync(merchOrder, cancellationToken);
            return Unit.Value;
        }
    }
}