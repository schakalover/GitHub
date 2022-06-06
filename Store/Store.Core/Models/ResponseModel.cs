using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Models
{
    public class ResponseModel<T>
    {
        public T? Model_name { get; set; }
        public bool? Success { get; set; }
        public int? Total_elements { get; set; }
    }
}
