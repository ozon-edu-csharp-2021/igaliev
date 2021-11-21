using MediatR;

namespace MerchandiseService.Infrastructure.Commands.CreateMerchOrder
{
    public class CreateMerchOrderCommand : IRequest<int>
    {
        public long EmployeeId { get; set; }
        public long ManagerId { get; set; }

        public int MerchKitId { get; set; }

        public int? ClothingSize { get; set; }
    }
}