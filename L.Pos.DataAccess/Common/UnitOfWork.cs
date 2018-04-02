using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Common
{
    public interface IUnitOfWork<TContext>
    {
        //ISession Session { get; set; }
        ISessionFactory _sessionFactory { get; set; }
        //void OpenNewSession(bool Yes = false);

        //void BeginTransaction(IsolationLevel IsolationLevel = IsolationLevel.ReadCommitted);
        //void Commit();
        //void Rollback();
    }

    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DatabaseContext
    {
        public ISessionFactory _sessionFactory { get; set; }
        //private ITransaction _transaction;

        //public ISession Session { get; set; }

        public UnitOfWork(TContext context)
        {
            if (_sessionFactory == null)
            {
                if (context.GetType() == typeof(SQLServerContext))
                {
                    _sessionFactory = context.GetSessionFactory(RunIn.Web, true);
                }
                else if (context.GetType() == typeof(MySQLContext))
                {
                    _sessionFactory = context.GetSessionFactory();
                }
            }

            //Session = _sessionFactory.OpenSession();
        }

        //public void OpenNewSession(bool Yes = false)
        //{
        //    if (Yes)
        //    {
        //        Session = _sessionFactory.OpenSession();
        //    }
        //}

        //public void BeginTransaction(IsolationLevel IsolationLevel = IsolationLevel.ReadCommitted)
        //{
        //    _transaction = Session.BeginTransaction(IsolationLevel);
        //}

        //public void Commit()
        //{
        //    try
        //    {
        //        _transaction.Commit();
        //    }
        //    catch
        //    {
        //        _transaction.Rollback();
        //        throw;
        //    }
        //    finally
        //    {
        //        Session.Close();
        //    }
        //}

        //public void Rollback()
        //{
        //    try
        //    {
        //        if (_transaction != null && _transaction.IsActive)
        //            _transaction.Rollback();
        //    }
        //    finally
        //    {
        //        Session.Dispose();
        //    }
        //}
    }
}
