using System;
using System.Collections.Generic;

namespace Store.Model.Store
{
    public partial class Store
    {
        public Store()
        {
            Articles = new HashSet<Article>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
    }
}
