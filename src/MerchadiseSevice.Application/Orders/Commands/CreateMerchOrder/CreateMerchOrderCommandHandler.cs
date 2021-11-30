using MediatR;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Domain.SeedWork;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Handlers.MerchOrder
{
    public class CreateMerchOrderCommandHandler : IRequestHandler<CreateMerchOrderCommand>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;
        public CreateMerchOrderCommandHandler(IMerchOrderRepository merchOrderRepository, IMediator mediator)
        {
            _merchOrderRepository = merchOrderRepository;
        }
        private void IssueMerch()
        {
            //TODO: запросить мерч, опрокинуть в сигнатуру модельку заказ
        }

        private bool CheckAvailability()
        {
            //TODO проверка на наличие в Stock Api, опрокинуть в сигнатуру модельку заказа
            throw new System.NotImplementedException();
        }

        public async Task<Unit> Handle(CreateMerchOrderCommand request, CancellationToken cancellationToken)
        {
            var merchOrder = new Domain.MerchOrderAggregation.MerchOrder(request.EmployeeId,
     Enumeration.GetAll<MerchKit>().FirstOrDefault(kit => kit.Id == request.MerchKitId));

            merchOrder.SetClothingSize(Enumeration.GetAll<ClothingSize>().FirstOrDefault(size => size.Id == request.ClothingSize));
            merchOrder.SetManagerId(request.EmployeeId);
            CheckAvailability();
            IssueMerch();
            await _merchOrderRepository.CreateAsync(merchOrder, cancellationToken);
            return Unit.Value;
        }


    }
}