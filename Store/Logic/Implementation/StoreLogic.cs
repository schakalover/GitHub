using Store.Core.DTO;
using Store.Core.Models;
using Store.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Infrastructure.Implementation
{
    public class StoreLogic : IStoreLogic
    {
        private readonly IStoreData _data;

        public StoreLogic(IStoreData data)
        {
            _data = data;
        }
        public async Task<ResponseModel<List<StoreDTO>>> GetAll()
        {
            List<StoreDTO> list = await _data.GetAll();
            ResponseModel<List<StoreDTO>> result = new ResponseModel<List<StoreDTO>>();
            result.Model_name = list;
            result.Total_elements = list.Count;
            result.Success = true;
            return result;
        }
    }
}
