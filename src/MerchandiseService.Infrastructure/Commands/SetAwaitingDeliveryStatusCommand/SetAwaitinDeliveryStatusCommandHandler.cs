using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;
using Microsoft.VisualBasic;

namespace MerchandiseService.Infrastructure.Commands.SetAwaitingDeliveryStatusCommand
{
    public class SetAwaitingDeliveryStatusCommandHandler:IRequestHandler<SetAwaitingDeliveryStatusCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;

        public SetAwaitingDeliveryStatusCommandHandler(IMerchOrderRepository merchOrderRepository)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public async Task<Unit> Handle(SetAwaitingDeliveryStatusCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = await _merchOrderRepository.FindByIdAsync(request.OrderId, cancellationToken);
            merchOrder.SetAwaitingDelivery();
            await _merchOrderRepository.UpdateAsync(merchOrder,cancellationToken);
            return Unit.Value;
        }
    }
}