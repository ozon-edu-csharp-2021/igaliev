


using MediatR;
using MerchandiseService.Infrastructure.Commands.CreateMerchOrder;
using MerchandiseService.Infrastructure.Repositories.Models;
using MerchService.Models;
using MerchService.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace MerchService.Controllers
{

    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;
        private readonly IMediator _mediator;


        public MerchandiseController(IMerchandiseService merchandiseService, IMediator mediator)
        {
            _merchandiseService = merchandiseService;
            _mediator = mediator;

        }

        [HttpGet("get/{id:long}")]
        public async Task<ActionResult<List<MerchItem>>> GetIssuingMerchInfo(long id, CancellationToken token)
        {

            var merchItems = await _merchandiseService.GetIssuingMerchInfo(id, token);
            if (String.IsNullOrWhiteSpace(merchItems))
            {
                return NotFound();
            }
            return Ok(merchItems);
        }

        [HttpPost("order/{id:long}")]
        public async Task<ActionResult<MerchItem>> GetMerchItem(CreateMerchOrderRequestDto createMerchOrderRequestDto, long id, CancellationToken cancelletionToken)
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