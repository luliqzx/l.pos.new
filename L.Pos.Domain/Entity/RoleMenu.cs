using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.Domain.Entity
{
    public class RoleMenu : BaseT<string>
    {
        public virtual Role Role { get; set; }
        public virtual Menu Menu { get; set; }

        public virtual IList<Privilege> Privileges { get; set; }

        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    RoleMenu o = obj as RoleMenu;
        //    if (o.Role == Role && o.Menu == Menu)
        //    {
        //        return true;
        //    }
        //    return false;
        //}

        //public override int GetHashCode()
        //{
        //    int i = 0;
        //    i = Role.GetHashCode() + 99 + Menu.GetHashCode();
        //    return i;
        //}
    }
}
