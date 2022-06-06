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
    public class StoreQueryHandler : IRequestHandler<StoreQuery, ResponseModel<List<StoreDTO>>>
    {
        private readonly IStoreLogic _itemRepository;
        public StoreQueryHandler(IStoreLogic storeLogic)
        {
            _itemRepository = storeLogic;
        }
        public async Task<ResponseModel<List<StoreDTO>>> Handle(StoreQuery request, CancellationToken cancellationToken)
        {
            return await _itemRepository.GetAll();
        }
    }
}
