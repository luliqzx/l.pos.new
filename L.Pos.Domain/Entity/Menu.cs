using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.Domain.Entity
{
    public class Menu : TEntity<string>
    {
        public virtual string Name { get; set; }
        public virtual string Active { get; set; }
        public virtual string Public { get; set; }
        public virtual string URL { get; set; }
        public virtual string PageMenu { get; set; }
        public virtual string Controller { get; set; }
        public virtual string Action { get; set; }

        public virtual IList<RoleMenu> RoleMenus { get; set; }
    }
}
