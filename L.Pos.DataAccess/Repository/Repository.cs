using L.Pos.DataAccess.Common;
using L.Pos.Domain.Entity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Repository
{
    public interface IRepository<T, TContext> where T : class where TContext : DatabaseContext
    {
        IQueryable<T> GetAll();
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        T GetBy(Func<T, bool> expr);

        ISession Session { get; set; }

        void BeginTransaction(IsolationLevel IsolationLevel = IsolationLevel.ReadCommitted);
        void Commit();
        void Rollback();
    }

    public class Repository<T, TContext> : IRepository<T, TContext> where T : class where TContext : DatabaseContext
    {
        private IUnitOfWork<TContext> _unitOfWork;
        private ITransaction _transaction;
        public Repository(IUnitOfWork<TContext> unitOfWork)
        {
            _unitOfWork = (UnitOfWork<TContext>)unitOfWork;
            Session = _unitOfWork._sessionFactory.OpenSession();
            //Session = _unitOfWork.Session;
        }

        public ISession Session { get; set; }

        public virtual IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public virtual void Create(T entity)
        {
            Session.Save(entity);
        }

        public virtual void Update(T entity)
        {
            Session.Update(entity);
        }

        public virtual void Delete(T entity)
        {
            Session.Delete(entity);
        }

        public void BeginTransaction(IsolationLevel IsolationLevel = IsolationLevel.ReadCommitted)
        {
            _transaction = Session.BeginTransaction(IsolationLevel);
        }

        public void Commit()
        {
            try
            {
                _transaction.Commit();
            }
            catch (Exception ex)
            {
                _transaction.Rollback();
                throw;
            }
            finally
            {
                //Session.Close();
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
                //Session.Dispose();
            }
        }

        public T GetBy(Func<T, bool> expr)
        {
            T t = Session.Query<T>().FirstOrDefault(expr);
            return t;
        }
    }
}
