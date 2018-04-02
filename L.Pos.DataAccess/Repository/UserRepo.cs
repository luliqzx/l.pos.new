using L.Pos.DataAccess.Common;
using L.Pos.Domain.Entity;
using NHibernate.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Repository
{
    public interface IUserRepo : IRepository<User, SQLServerContext>
    {
    }

    public class UserRepo : Repository<User, SQLServerContext>, IUserRepo
    {
        public UserRepo(IUnitOfWork<SQLServerContext> unitOfWork) : base(unitOfWork)
        {
        }

        //public User GetUserBy(Func<User, bool> expr)
        //{
        //    User user = Session.Query<User>().FirstOrDefault(expr);
        //    return user;
        //}
    }
}
