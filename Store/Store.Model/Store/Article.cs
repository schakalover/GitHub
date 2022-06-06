using System;
using System.Collections.Generic;

namespace Store.Model.Store
{
    public partial class Article
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public decimal? Price { get; set; }
        public int? TotalInShelf { get; set; }
        public int? TotalInVault { get; set; }
        public int StoreId { get; set; }

        public virtual Store Store { get; set; } = null!;
    }
}
