using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.DTO
{
    public class ArticleDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? TotalInShelf { get; set; }
        public int? TotalInVault { get; set; }
        public int StoreId { get; set; }

        public virtual StoreDTO Store { get; set; } = null!;
    }
}
