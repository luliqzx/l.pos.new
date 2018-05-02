using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.Domain.Entity
{
    public class Privilege : BaseT<string>
    {
        public virtual string Name { get; set; }
    }
}
