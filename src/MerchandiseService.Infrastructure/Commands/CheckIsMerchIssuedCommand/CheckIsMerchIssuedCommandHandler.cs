using MediatR;
using MerchandiseService.Infrastructure.Repositories.Infastructure;
using MerchandiseService.Infrastructure.Repositories.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MerchandiseService.Infrastructure.Commands.CheckIsMerchIssuedCommand
{
    class CheckIsMerchIssuedCommandHandler : IRequestHandler<CheckIsMerchIssuedCommand,KitIssuedDto>

    {
        //TODO: опрокинуть репозиторий через UnitOfWork и зарегистрировать его в сервисах
        private readonly IIssuedKitRepository _issuedKitRepository;

        public CheckIsMerchIssuedCommandHandler(IIssuedKitRepository issuedKitRepository)
        {
            _issuedKitRepository = issuedKitRepository;
        }

        public async Task<KitIssuedDto> Handle(CheckIsMerchIssuedCommand request, CancellationToken cancellationToken)
        {
            var result = await _issuedKitRepository.CheckIsKitIssuied(request.EmployeeId, request.MerckKitId, cancellationToken);
            return result;
        }
}
}
