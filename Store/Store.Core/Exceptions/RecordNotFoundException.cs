using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Core.Exceptions
{
    public class RecordNotFoundException : Exception
    {
        public RecordNotFoundException(string mensaje) : base(mensaje)
        {

        }
    }
}
