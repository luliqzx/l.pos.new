using FluentNHibernate.Mapping;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Map
{
    public class MenuMap : ClassMap<Menu>
    {
        public MenuMap()
        {
            Id(x => x.ID).Length(10).GeneratedBy.Assigned();
            Map(x => x.Name);

            Map(x => x.Active).Default("Y").Length(1);
            Map(x => x.Public).Default("Y").Length(1);
            Map(x => x.URL);
            Map(x => x.PageMenu);
            Map(x => x.Controller);
            Map(x => x.Action);

            HasMany(x => x.RoleMenus);

            #region Audit Trail
            Map(x => x.CreateBy);
            Map(x => x.CreateDate);
            Map(x => x.CreateTerimal);
            Map(x => x.UpdateBy);
            Map(x => x.UpdateDate);
            Map(x => x.UpdateTerminal);
            Version(x => x.Row_Version);
            #endregion
        }
    }
}


