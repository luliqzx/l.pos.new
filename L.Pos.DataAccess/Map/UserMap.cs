using FluentNHibernate.Mapping;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Map
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Id(x => x.ID).GeneratedBy.Identity();
            Map(x => x.Username).Length(25).Unique().Not.Nullable();
            Map(x => x.Password);

            #region Audit Trail
            Map(x => x.CreateBy);
            Map(x => x.CreateDate);
            Map(x => x.CreateTerimal);
            Map(x => x.UpdateBy);
            Map(x => x.UpdateDate);
            Map(x => x.UpdateTerminal);
            Version(x => x.Timestamp);
            #endregion
        }
    }
}
