using FluentNHibernate.Mapping;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Map
{
    public class RoleMenuMap : ClassMap<RoleMenu>
    {
        public RoleMenuMap()
        {
            //CompositeId()
            //    .KeyReference(x => x.Role)
            //    .KeyReference(x => x.Menu);
            Id(x => x.ID).Length(20).GeneratedBy.Assigned();
            References(x => x.Role);
            References(x => x.Menu);
            HasManyToMany(x => x.Privileges).Table("RoleMenuPrivilege");
        }
    }
}
