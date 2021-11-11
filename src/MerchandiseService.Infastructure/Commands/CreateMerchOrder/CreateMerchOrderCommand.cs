using MediatR;

namespace MerchandiseService.Infastructure.Commands.CreateMerchOrder
{
    public class CreateMerchOrderCommand : IRequest<int>
    {
        public long EmployeeId { get; set; }
        public long ManagerId { get; set; }

        public int MerchPack { get; set; }

        public int? ClothingSize { get; set; }
    }
}