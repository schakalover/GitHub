using Store.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data
{
    public interface IArticleData
    {
        Task<List<ArticleDTO>> GetAll();
        Task<List<ArticleDTO>> GetByStore(int idStore);
    }
}
