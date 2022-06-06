using Store.Core.DTO;
using Store.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure
{
    public interface IArticleLogic
    {
        Task<ResponseModel<List<ArticleDTO>>> GetAll();
        Task<ResponseModel<List<ArticleDTO>>> GetByStore(string idStore);
    }
}
