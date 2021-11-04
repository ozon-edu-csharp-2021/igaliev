using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public class MerchOrderStatus:Enumeration
    {
        public static MerchOrderStatus Created = new MerchOrderStatus(1, nameof(Created).ToLowerInvariant());
        public static MerchOrderStatus InQueueForIssue = new MerchOrderStatus(2, nameof(InQueueForIssue).ToLowerInvariant());
        public static MerchOrderStatus InProgress  = new MerchOrderStatus(3, nameof(InProgress).ToLowerInvariant());
        public static MerchOrderStatus Done = new MerchOrderStatus(5, nameof(Done).ToLowerInvariant());
        public MerchOrderStatus(int id, string name) : base(id, name)
        {
        }
    }
}