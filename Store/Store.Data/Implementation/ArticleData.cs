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
    public class ArticleData : IArticleData
    {
        private readonly IMapper _mapper;
        private readonly StoredContext _context;

        public ArticleData(IMapper mapper, StoredContext context)
        {
            _mapper = mapper;
            _context = context;
        }
        public async Task<List<ArticleDTO>> GetAll()
        {
            var query = await _context.Articles.AsNoTracking().ToListAsync();
            return _mapper.Map<List<ArticleDTO>>(query);
        }

        public async Task<List<ArticleDTO>> GetByStore(int idStore)
        {
            var query = await _context.Articles.AsNoTracking().Where(x => x.StoreId == idStore).ToListAsync();
            return _mapper.Map<List<ArticleDTO>>(query);
        }
    }
}
