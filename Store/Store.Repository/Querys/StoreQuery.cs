using MediatR;
using Store.Core.DTO;
using Store.Core.Models;

namespace Store.Domain.Querys
{
    public class StoreQuery : IRequest<ResponseModel<List<StoreDTO>>>
    {
    }
}
