using System.Threading;
using System.Threading.Tasks;
using MediatR;
using MerchadiseSevice.Application.Interfaces;

namespace MerchadiseSevice.Application.Orders.Queries.CheckIsMerchIssuedQuery
{
    public class CheckIsMerchIssuedQueryHandler: IRequestHandler<CheckIsMerchIssuedQuery,KitIssuedDto>

    {
        //TODO: опрокинуть репозиторий через UnitOfWork и зарегистрировать его в сервисах
        private readonly IIssuedKitRepository _issuedKitRepository;



        public async Task<KitIssuedDto> Handle(CheckIsMerchIssuedQuery request, CancellationToken cancellationToken)
        {
            var result = await _issuedKitRepository.CheckIsKitIssuied(request.EmployeeId, request.MerckKitId, cancellationToken);
            return result;
        }
    }
    
}