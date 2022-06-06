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
    public class ArticlesController : BaseApiController
    {
        private readonly IMediator _mediator;

        public ArticlesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(ResponseModel<List<ArticleDTO>>))]
        [Produces("application/json")]
        public async Task<ActionResult> GetAll()
        {
            RequestModel<ArticleQuery> request = new RequestModel<ArticleQuery>();
            request.Data = new ArticleQuery();
            return await this.HandleOperationExecutionAsync(async () => { return Ok(await _mediator.Send(request.Data)); });
        }

        [HttpGet, Route("stores/{store_id}")]
        [ProducesResponseType(200, Type = typeof(ResponseModel<List<ArticleDTO>>))]
        [Produces("application/json")]
        public async Task<ActionResult> GetByStore(string store_id)
        {
            RequestModel<ArticleByStoreQuery> request = new RequestModel<ArticleByStoreQuery>();
            request.Data = new ArticleByStoreQuery();
            request.Data.StoreId = store_id;
            return await this.HandleOperationExecutionAsync(async () => { return Ok(await _mediator.Send(request.Data)); });
        }
    }
}
