using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.Events;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.SeedWork;
using System;

namespace MerchandiseService.Domain.MerchOrderAggregation
{
    public class MerchOrder : Entity, IAggregateRoot
    {
        public MerchOrderStatus Status { get; private set; }

        public long EmployeeId { get; }
        public long ManagerId { get; private set; }
        public MerchKit MerchKit { get; }

        public ClothingSize ClothingSize { get; private set; }

        private DateTime _orderDate;

        public MerchOrder(long employeeId, MerchKit merchKit)
        {
            EmployeeId = employeeId;
            MerchKit = merchKit;
            Status = MerchOrderStatus.Created;
            _orderDate = DateTime.UtcNow;
        }

        public void SetClothingSize(ClothingSize clothingSize)
        {
            ClothingSize = clothingSize;
        }

        public void SetManagerId(long id)
        {
            ManagerId = id;
        }

        public void SetAvaitingVerificationStatus()
        {
            if (Status == MerchOrderStatus.Created)
            {
                AddDomainEvent(new MerchOrderAwaitingVerificationDomainEvent(Id, MerchKit));
                Status = MerchOrderStatus.AwaitingVerification;

            }
            else
            {
                StatusChangeException(MerchOrderStatus.AwaitingVerification);
            }
        }
        public void SetCancelledStatus()
        {
            if (Status == MerchOrderStatus.Completed)
            {
                StatusChangeException(MerchOrderStatus.Completed);
            }
            else
            {
                AddDomainEvent(new MerchOrderCancelledDomainEvent(this));
                Status = MerchOrderStatus.Cancelled;
            }
        }
        public void SetCompletedStatus()
        {
            if (Status == MerchOrderStatus.PendingIssue)
            {
                AddDomainEvent(new MerchOrderPendingIssueDomainEvent(Id));
                Status = MerchOrderStatus.PendingIssue;
            }
            else
            {
                StatusChangeException(MerchOrderStatus.Completed);
            }
        }
        public void SetPendingIssueStatus()
        {
            if (Status == MerchOrderStatus.AwaitingDelivery || Status == MerchOrderStatus.AwaitingVerification)
            {
                AddDomainEvent(new MerchOrderPendingIssueDomainEvent(Id));
                Status = MerchOrderStatus.PendingIssue;
            }
            else
            {
                StatusChangeException(MerchOrderStatus.PendingIssue);
            }
        }
        public void SetAwaitingDelivery()
        {
            if (Status == MerchOrderStatus.AwaitingVerification)
            {
                AddDomainEvent(new MerchOrderAwaitingDeliveryDomainEvent(Id));
                Status = MerchOrderStatus.AwaitingDelivery;

            }
            else
            {
                StatusChangeException(MerchOrderStatus.AwaitingDelivery);
            }
        }



        private void StatusChangeException(MerchOrderStatus orderStatusToChange)
        {
            throw new DomainOrderException($"Is not possible to change the order status from {Status.Name} to {orderStatusToChange.Name}.");
        }

    }
}