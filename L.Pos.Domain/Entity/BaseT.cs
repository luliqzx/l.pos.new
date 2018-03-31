using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.Domain.Entity
{
   public class BaseT<TID>
    {
        public virtual TID ID { get; set; }
    }
}
