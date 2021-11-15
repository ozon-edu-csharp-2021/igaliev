using MerchandiseService.Domain.AggregatesModels.PersonsAggregation.EmployeeAggregation;
using MerchandiseService.Domain.Exceptions;
using MerchandiseService.Domain.MerchOrderAggregation;
using Xunit;

namespace MerchandiseService.Domain.Tests
{
    public class MerchOrderTests
    {
        [Fact]
        public void SetClothingSize()
        {

            var merchOrder = new MerchOrder(1, MerchKit.WelcomePack);

            merchOrder.SetClothingSize(ClothingSize.L);

            Assert.Equal(merchOrder.ClothingSize, ClothingSize.L);

        }
        [Fact]
        public void SetManagerId()
        {

            var merchOrder = new MerchOrder(1, MerchKit.WelcomePack);

            merchOrder.SetManagerId(5);

            Assert.Equal(5, merchOrder.ManagerId);

        }

        [Fact]
        public void SetAvaitingVerificationStatus()
        {

            var merchOrder = new MerchOrder(1, MerchKit.WelcomePack);

            Assert.Equal(merchOrder.Status,MerchOrderStatus.Created );

        }
        [Fact]
        public void SetCancelledStatus()
        {

            var merchOrder = new MerchOrder(1, MerchKit.WelcomePack);


            Assert.Equal(merchOrder.Status, MerchOrderStatus.Created);

        }
        [Fact]
        public void SetCompletedStatus()
        {

            var merchOrder = new MerchOrder(1, MerchKit.WelcomePack);


                Assert.Throws<DomainOrderException>(() => merchOrder.SetCompletedStatus());

            }
        [Fact]
        public void SetPendingIssueStatus()
        {

            var merchOrder = new MerchOrder(1, MerchKit.WelcomePack);



                Assert.Throws<DomainOrderException>(() => merchOrder.SetPendingIssueStatus());

            }
        [Fact]
        public void SetAwaitingDelivery()
        {

            var merchOrder = new MerchOrder(1, MerchKit.WelcomePack);

                Assert.Throws<DomainOrderException>(() => merchOrder.SetAwaitingDelivery());

         }
    }
}