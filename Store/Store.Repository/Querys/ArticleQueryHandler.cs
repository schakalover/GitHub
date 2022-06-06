using MediatR;
using Store.Core.DTO;
using Store.Core.Models;
using Store.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Querys
{
    public  class ArticleQueryHandler : IRequestHandler<ArticleQuery, ResponseModel<List<ArticleDTO>>>, IRequestHandler<ArticleByStoreQuery, ResponseModel<List<ArticleDTO>>>
    {
        private readonly IArticleLogic _itemRepository;

        public ArticleQueryHandler(IArticleLogic articleLogic)
        {
            _itemRepository = articleLogic;
        }

        public async Task<ResponseModel<List<ArticleDTO>>> Handle(ArticleQuery request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetAll();
        }

        public async Task<ResponseModel<List<ArticleDTO>>> Handle(ArticleByStoreQuery request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetByStore(request.StoreId);
        }
    }
}
