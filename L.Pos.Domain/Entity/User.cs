using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.Domain.Entity
{
    public class User : TEntity<int>
    {
        public virtual string Username { get; set; }
        public virtual string Password { get; set; }
    }
}
