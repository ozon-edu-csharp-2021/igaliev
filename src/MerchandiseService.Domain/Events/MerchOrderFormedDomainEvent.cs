using MediatR;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.MerchOrderAggregation;


namespace MerchandiseService.Domain.Events
{
    public class MerchOrderFormedDomainEvent : INotification
    {
        public MerchKit MerchKit{ get; }
        public ClothingSize ClothingSize { get; }

        public long MerchOrderId { get; }

        public MerchOrderFormedDomainEvent(long merchOrderId,  ClothingSize clothingSize, MerchKit merchKit)
        {
            MerchOrderId = merchOrderId;
          
            ClothingSize = clothingSize;
            MerchKit = merchKit;
        }
    }
}