using Store.Core.DTO;
using Store.Core.Exceptions;
using Store.Core.Models;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Implementation
{
    public class ArticleLogic : IArticleLogic
    {
        private readonly IArticleData _data;
        public ArticleLogic(IArticleData data)
        {
            _data = data;
        }

        public async Task<ResponseModel<List<ArticleDTO>>> GetAll()
        {
            List<ArticleDTO> list = await _data.GetAll();
            ResponseModel<List<ArticleDTO>> result = new ResponseModel<List<ArticleDTO>>();
            result.Model_name = list;
            result.Total_elements = list.Count;
            result.Success = true;
            return result;
        }

        public async Task<ResponseModel<List<ArticleDTO>>> GetByStore(string idStore)
        {

            ResponseModel<List<ArticleDTO>> result = new ResponseModel<List<ArticleDTO>>();
            int idStoreResult;
            bool isNumber = Int32.TryParse(idStore,out idStoreResult);

            if (!isNumber)
            {
                throw new BadRequestException("Wrong parameters (id is not a number)");
            }

            List<ArticleDTO> list = await _data.GetByStore(idStoreResult);

            if (list.Count < 1)
            {
                throw new RecordNotFoundException("No store with that ID");
            }

            result.Model_name = list;
            result.Total_elements = list.Count;
            result.Success = true;
            return result;
        }
    }
}
