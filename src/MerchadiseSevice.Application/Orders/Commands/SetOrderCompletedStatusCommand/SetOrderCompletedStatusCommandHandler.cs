using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Commands.SetOrderCompletedStatusCommand
{
    public class SetOrderCompletedStatusCommandHandler : IRequestHandler<SetOrderCompletedStatusCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public SetOrderCompletedStatusCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<Unit> Handle(SetOrderCompletedStatusCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            merchOrder.SetCompletedStatus();
            await _merchOrderRepository.UpdateAsync(merchOrder, cancellationToken);
            return Unit.Value;
        }
    }
}