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
            Id(x => x.ID).Length(10).GeneratedBy.Assigned();
            Map(x => x.Name).Length(50).Unique().Not.Nullable();
            //References(x => x.MainRole);
            HasMany(x => x.RoleMenu);
        }
    }
}
