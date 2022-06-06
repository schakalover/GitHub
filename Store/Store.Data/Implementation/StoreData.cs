using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Store.Core.DTO;
using Store.Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.Implementation
{
    public class StoreData : IStoreData
    {
        private readonly IMapper _mapper;
        private readonly StoredContext _context;

        public StoreData(IMapper mapper, StoredContext context)
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<StoreDTO>> GetAll()
        {
            var query = await _context.Stores.AsNoTracking().ToListAsync();
            return _mapper.Map<List<StoreDTO>>(query);
        }
    }
}
