using MediatR;
using MerchandiseService.Infrastructure.Repositories.Models;


namespace MerchandiseService.Infrastructure.Commands.CheckIsMerchIssuedCommand
{
  public  class CheckIsMerchIssuedCommand:IRequest<KitIssuedDto>
    {
      public  int EmployeeId { get; set; }
      public int MerckKitId { get; set; }
    }
}
