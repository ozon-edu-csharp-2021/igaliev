using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Domain.SeedWork;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;

namespace MerchandiseService.Infrastructure.Handlers.MerchOrder
{
    public class CreateMerchOrderCommandHandler:IRequestHandler<CreateMerchOrderCommand,int>
    {
        private readonly IMerchOrderRepository _merchOrderRepository;
        public CreateMerchOrderCommandHandler(IMerchOrderRepository merchOrderRepository, IMediator mediator)
        {
            _merchOrderRepository = merchOrderRepository;
        }

        public  Task<int> Handle(CreateMerchOrderCommand request, CancellationToken cancellationToken)
        {
            //TODO: добавить проверки
            var merchOrder = new Domain.MerchOrderAggregation.MerchOrder(request.EmployeeId, 
                Enumeration.GetAll<MerchKit>().FirstOrDefault(kit => kit.Id == request.MerchKitId));

            merchOrder.SetClothingSize(Enumeration.GetAll<ClothingSize>().FirstOrDefault(size=>size.Id == request.ClothingSize));
            merchOrder.SetManagerId(request.EmployeeId);
            CheckAvailability();
            IssueMerch();
            return   _merchOrderRepository.Add(merchOrder,cancellationToken);
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
    }
}