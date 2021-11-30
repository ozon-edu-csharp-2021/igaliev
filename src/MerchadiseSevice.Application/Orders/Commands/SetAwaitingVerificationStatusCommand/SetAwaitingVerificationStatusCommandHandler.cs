using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Commands.SetAwaitingVerificationStatusCommand
{
    public class SetAwaitingVerificationStatusCommandHandler : IRequestHandler<SetAwaitingVerificationStatusCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public SetAwaitingVerificationStatusCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<Unit> Handle(SetAwaitingVerificationStatusCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            merchOrder.SetAvaitingVerificationStatus();
            await _merchOrderRepository.UpdateAsync(merchOrder, cancellationToken);
            return Unit.Value;
        }
    }
}