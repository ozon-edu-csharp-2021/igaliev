using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Commands.CreateMerchOrder
{
    class CreateMerchOrderCommandValidator : AbstractValidator<CreateMerchOrderCommand>
    {
        public CreateMerchOrderCommandValidator()
        {
            RuleFor(CreateMerchOrder => CreateMerchOrder.ClothingSize).NotNull().GreaterThan(0);
            RuleFor(CreateMerchOrder => CreateMerchOrder.EmployeeId).NotNull().GreaterThan(0);
            RuleFor(CreateMerchOrder => CreateMerchOrder.ManagerId).NotNull().GreaterThan(0);
            RuleFor(CreateMerchOrder => CreateMerchOrder.MerchKitId).NotNull().GreaterThan(0);

        }
    }
}
