using AutoMapper;
using Store.Core.DTO;
using Store.Model.Store;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Data.AutoMapper
{
    public class AutoMapperEntitys :Profile
    {
        public AutoMapperEntitys()
        {
            CreateMap<ArticleDTO, Article>().ReverseMap();
            CreateMap<StoreDTO, Store.Model.Store.Store>().ReverseMap();
        }

        public static void Configuration() { }
    }
}
