using MediatR;
using Store.Core.DTO;
using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Querys
{
    public class ArticleQuery : IRequest<ResponseModel<List<ArticleDTO>>>
    {
    }
}
