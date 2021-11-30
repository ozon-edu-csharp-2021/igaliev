using FluentValidation;


namespace MerchadiseSevice.Application.Orders.Queries.CheckIsMerchIssuedQuery
{
    public class CheckIsMerchIssuedQueryValidator : AbstractValidator<CheckIsMerchIssuedQuery>
    {
        public CheckIsMerchIssuedQueryValidator()
        {
            RuleFor(CheckIsMerchIssuedCommand => CheckIsMerchIssuedCommand.EmployeeId).NotNull().WithMessage("Id сотрудника не иожет быть пустым")
                .GreaterThan(0).WithMessage("Id не может быть меньше 1");
            RuleFor(CheckIsMerchIssuedCommand => CheckIsMerchIssuedCommand.MerckKitId).NotNull().WithMessage("Id набора не может быть пустым")
                .GreaterThan(0).WithMessage("Id не может быть меньше 1")
                .LessThan(6).WithMessage("Id набора не может быть больше 5");
        }
    }
}