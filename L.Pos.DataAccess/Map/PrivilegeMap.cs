using FluentNHibernate.Mapping;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Map
{
    public class PrivilegeMap : ClassMap<Privilege>
    {
        public PrivilegeMap()
        {
            Id(x => x.ID).Length(10);
            Map(x => x.Name);
        }
    }
}
