using MediatR;
using MerchandiseService.Domain.MerchOrderAggregation;
using MerchandiseService.Infrastructure.Commands.CheckIsMerchIssuedCommand;
using MerchandiseService.Infrastructure.Repositories.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MerchService.Controllers
{
    [ApiController]
    [Route("v1/api/issuerequest")]
 
    public class IssueRequestController:ControllerBase
    {
        private readonly IMediator _mediator;

        public IssueRequestController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("is-kit-issued/{employeeId:int}/{merchKitId:int}")]
        public async Task<ActionResult<KitIssuedDto>> IsMerchKitIssued(int employeeId, int merchKitId, CancellationToken cancelletionToken)
        {
            var command = new CheckIsMerchIssuedCommand {
                EmployeeId = employeeId,
                MerckKitId = merchKitId
            };
            var result = await _mediator.Send(command, cancelletionToken);
            return Ok(result);
        }

       [HttpGet("orderMerchKit/{employeeId:int}/{merchKitId:int}")]
       public async Task<ActionResult<int>> OrderMerchKitForEmployee(int employeeId, int merchKitId, CancellationToken cancelletionToken)
        {
            return Ok(2);
        }
    }
   
}
