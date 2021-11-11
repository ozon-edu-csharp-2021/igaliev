using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public class MerchOrderStatus : Enumeration
    {
        //Создан заказ
        public static MerchOrderStatus Created = new MerchOrderStatus(1, nameof(Created).ToLowerInvariant());
        //Заказ ожидает проверку на наличие
        public static MerchOrderStatus AwaitingVerification = new MerchOrderStatus(2, nameof(AwaitingVerification).ToLowerInvariant());
        //Ожидает поставки
        public static MerchOrderStatus AwaitingDelivery = new MerchOrderStatus(3, nameof(AwaitingDelivery).ToLowerInvariant());
        //Ожидает выдачи
        public static MerchOrderStatus PendingIssue = new MerchOrderStatus(4, nameof(PendingIssue).ToLowerInvariant());
        // Заказ отменен
        public static MerchOrderStatus Cancelled = new MerchOrderStatus(5, nameof(Cancelled).ToLowerInvariant());
        //Заказ завершен
        public static MerchOrderStatus Completed = new MerchOrderStatus(6, nameof(Completed).ToLowerInvariant());
        public MerchOrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}