using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Common
{
    public interface IUnitOfWork<TContext>
    {
        ISession Session { get; set; }

        void BeginTransaction();
        void Commit();
        void Rollback();
    }

    public class UnitOfWork<TContext> : IUnitOfWork<TContext> where TContext : DatabaseContext
    {
        private ISessionFactory _sessionFactory;
        private ITransaction _transaction;

        public ISession Session { get; set; }

        public UnitOfWork(TContext context)
        {
            if (_sessionFactory == null)
            {
                _sessionFactory = context.GetSessionFactory();
            }

            Session = _sessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                Session.Close();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
