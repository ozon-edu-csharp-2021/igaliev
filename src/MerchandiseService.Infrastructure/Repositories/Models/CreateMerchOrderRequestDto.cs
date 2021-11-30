namespace MerchandiseService.Infrastructure.Repositories.Models
{
    public class CreateMerchOrderRequestDto
    {
        public long EmployeeId { get; set; }
        public long ManagerId { get; set; }
        public int MerchKitId { get; set; }
        public int? ClothingSize { get; set; }

    }
}
