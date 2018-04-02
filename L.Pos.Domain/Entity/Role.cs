using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.Domain.Entity
{
    public class Role : TEntity<string>
    {
        public virtual string Name { get; set; }
        public virtual Role MainRole { get; set; }
    }
}
