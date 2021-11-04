using System;
using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.Events;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.SeedWork;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public class MerchOrder : Entity, IAggregateRoot
    {
       public MerchOrderStatus Status { get; private set; }

        public long EmployeeId { get; }
        public long ManagerId { get; }

        public MerchKit MerchKit { get; }

        public ClothingSize ClothingSize { get; private set; }

        public Date DateOfIssue { get; private set; }

        public MerchOrder(long employeeId,  long managerId, MerchKit merchKit)
        {
            EmployeeId = employeeId;
            ManagerId = managerId;
            MerchKit = merchKit;

            Status = MerchOrderStatus.Created;
        }

        public void SetClothingSize(ClothingSize clothingSize)
        {
            ClothingSize = clothingSize;
        }

        public void MoveToQueue()
        {
            if (Status != MerchOrderStatus.InProgress)
            {
                throw new IncorrectOrderStatusException("Status should be InProgress");
            }

            Status = MerchOrderStatus.InQueueForIssue;
        }

        public void CheckAvailability()
        {
            if (Status != MerchOrderStatus.Created && Status != MerchOrderStatus.InQueueForIssue)
            {
                throw new IncorrectOrderStatusException("Status should be Created or InQueueForIssue");
            }

            if (MerchKit.IsNeedSize && ClothingSize == null)
            {
                throw new ClothingSizeException("Size must be specified");
            }

            Status = MerchOrderStatus.InProgress;
            AddMerchOrderFormedDomainEvent(Id, MerchKit, ClothingSize);
        }

        public void Complete()
        {
            if (Status != MerchOrderStatus.InProgress)
            {
                throw new IncorrectOrderStatusException("Status should be InProgress");
            }

            Status = MerchOrderStatus.Done;
            var currentDate = DateTime.Today;
            DateOfIssue = new Date(currentDate.Day, currentDate.Month, currentDate.Year);
            AddMerchOrderReadyToIssueDomainEvent(EmployeeId);
        }

        private void AddMerchOrderReadyToIssueDomainEvent(long employeeId)
        {
            var merchOrderReadyToIssueDomainEvent = new MerchOrderReadyToIssueDomainEvent(employeeId);
            
            this.AddDomainEvent(merchOrderReadyToIssueDomainEvent);
        }

        private void AddMerchOrderFormedDomainEvent(long merchOrderId, MerchKit merchKit, ClothingSize clothingSize)
        {
            var merchOrderFormedDomainEvent = new MerchOrderFormedDomainEvent(merchOrderId,  clothingSize,merchKit);
            this.AddDomainEvent(merchOrderFormedDomainEvent);
        }
    }
}