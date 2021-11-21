using MediatR;

namespace MerchadiseSevice.Application.Orders.Queries.CheckIsMerchIssuedQuery
{
    public class CheckIsMerchIssuedQuery:IRequest<KitIssuedDto>
    {
        public  int EmployeeId { get; set; }
        public int MerckKitId { get; set; }
    }
}