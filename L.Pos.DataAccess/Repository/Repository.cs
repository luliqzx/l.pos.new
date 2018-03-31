using L.Pos.DataAccess.Common;
using L.Pos.Domain.Entity;
using NHibernate;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
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

        ISession Session { get; }
    }

    public class Repository<T, TContext> : IRepository<T, TContext> where T : class where TContext : DatabaseContext
    {
        private IUnitOfWork<TContext> _unitOfWork;
        public Repository(IUnitOfWork<TContext> unitOfWork)
        {
            _unitOfWork = (UnitOfWork<TContext>)unitOfWork;
        }

        public ISession Session { get { return _unitOfWork.Session; } }

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
    }
}
