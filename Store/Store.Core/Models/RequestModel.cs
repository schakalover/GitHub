﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Models
{
    public class RequestModel<T>
    {
        public T Data { get; set; }
    }
}
