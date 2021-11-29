using MediatR;
using MerchandiseService.Infrastructure.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;

namespace MerchService.Controllers
{
    [ApiController]
    [Route("v1/api/issuedrequest")]
 
    public class IssueRequestController:ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("is-kit-issued/{employeeId:int}/{merchKitId:int}")]
       // public async Task<ActionResult<KitIssuedDto>> IsMerchKitIssued(int employeeId, int merchKitId, CancellationToken cancelletionToken)
       // {
       //     var command = new CheckIsMerchIssuedCommand {
           //     EmployeeId = employeeId,
         //       MerckKitId = merchKitId
         //   };
         //   var result = await _mediator.Send(command, cancelletionToken);
           // return Ok(result);
      //  }

       [HttpPost("orderMerchKit")]
       public async Task<ActionResult<int>> OrderMerchKitForEmployee(CreateMerchOrderRequestDto createMerchOrderRequestDto ,CancellationToken cancelletionToken)
        {
            var command = new CreateMerchOrderCommand
            {
                ClothingSize = createMerchOrderRequestDto.ClothingSize,
                EmployeeId = createMerchOrderRequestDto.EmployeeId,
                ManagerId = createMerchOrderRequestDto.ManagerId,
                MerchKitId = createMerchOrderRequestDto.MerchKitId
            };
            var result = await _mediator.Send(command, cancelletionToken);
            return Ok(result);
        }
    }
   
}
