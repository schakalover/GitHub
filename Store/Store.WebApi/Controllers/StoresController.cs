using MediatR;
using Microsoft.AspNetCore.Mvc;
using Store.Core.DTO;
using Store.Core.Models;
using Store.Core.Web;
using Store.Domain.Querys;

namespace Store.WebApi.Controllers
{
    [Route("services/[controller]")]
    [ApiController]
    public class StoresController : BaseApiController
    {
        private readonly IMediator _mediator;

        public StoresController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponseModel<List<StoreDTO>>))]
        [Produces("application/json")]
        public async Task<ActionResult> GetAll()
        {
            RequestModel<StoreQuery> request = new RequestModel<StoreQuery>();
            request.Data = new StoreQuery();
            return await this.HandleOperationExecutionAsync(async () => { return Ok(await _mediator.Send(request.Data)); });
        }
    }
}
