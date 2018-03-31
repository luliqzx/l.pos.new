using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using L.Pos.DataAccess.Map;
using NHibernate;
using NHibernate.Cfg;
using NHibernate.Context;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Common
{
    public enum RunIn
    {
        Web,
        Desktop
    }

    public abstract class DatabaseContext
    {
        public abstract ISessionFactory GetSessionFactory(RunIn RunIn = RunIn.Web, bool IsUpdateSchema = false);
        protected static void UpdateSchema(Configuration cfg)
        {
            new SchemaUpdate(cfg)
                .Execute(false, true);
        }

    }

    public class SQLServerContext : DatabaseContext
    {
        public override ISessionFactory GetSessionFactory(RunIn RunIn = RunIn.Web, bool IsUpdateSchema = false)
        {
            FluentConfiguration fc = Fluently.Configure();
            fc.Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("mssqlserverconn")))
                          //.Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("QCEntities")))
                          .Mappings(m => m.FluentMappings.Add<UserMap>());
            if (RunIn == RunIn.Web)
            {
                fc.CurrentSessionContext<WebSessionContext>();
            }
            else
            {
                fc.CurrentSessionContext<CallSessionContext>();
            }
            if (IsUpdateSchema)
            {
                fc.ExposeConfiguration(UpdateSchema);
            }
            return fc.BuildSessionFactory();
        }
    }

    public class MySQLContext : DatabaseContext
    {
        public override ISessionFactory GetSessionFactory(RunIn RunIn = RunIn.Web, bool IsUpdateSchema = false)
        {
            return Fluently.Configure()
                          .Database(MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("mssqlserverconn2")))
                          .Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.Load("L.Pos.DataAccess")))
                          .CurrentSessionContext<WebSessionContext>()
                          .BuildSessionFactory();
        }
    }
}
