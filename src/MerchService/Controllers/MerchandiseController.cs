
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MerchService.Models;
using MerchService.Services;
using Microsoft.AspNetCore.Mvc;

namespace MerchService.Controllers
{
   
    [ApiController]
    [Route("v1/api/merchandise")]
    [Produces("application/json")]
    public class MerchandiseController : ControllerBase
    {
        private readonly IMerchandiseService _merchandiseService;

        public MerchandiseController(IMerchandiseService merchandiseService)
        {
            _merchandiseService = merchandiseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<MerchItem>>> GetIssuingMerchInfo(long id, CancellationToken token)
        {

            var merchItems = await _merchandiseService.GetIssuingMerchInfo(id,token);
            return Ok(merchItems);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<MerchItem>> GetMerchItem(long id, CancellationToken token)
        {

           // var merchItem = await _merchandiseService.GetMerchItem(id, token);
           // if (merchItem is null)
           // {
           //     return NotFound();
           // }
            return Ok();
        }
    }

}