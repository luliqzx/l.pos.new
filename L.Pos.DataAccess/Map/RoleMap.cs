using FluentNHibernate.Mapping;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Map
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Id(x => x.ID).GeneratedBy.Assigned();
            Map(x => x.Name).Length(50).Unique().Not.Nullable();
            References(x => x.MainRole, "MainRole").Cascade.All();
        }
    }
}
