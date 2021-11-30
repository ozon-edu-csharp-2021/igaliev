using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Commands.SetOrderCancelledStatusCommand
{
    public class SetOrderCancelledCommandHandler : IRequestHandler<SetOrderCancelledStatusCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public SetOrderCancelledCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<Unit> Handle(SetOrderCancelledStatusCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            merchOrder.SetCancelledStatus();
            await _merchOrderRepository.UpdateAsync(merchOrder, cancellationToken);
            return Unit.Value;

        }
    }
}