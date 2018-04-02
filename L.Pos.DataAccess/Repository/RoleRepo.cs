using L.Pos.DataAccess.Common;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace L.Pos.DataAccess.Repository
{
    public interface IRoleRepo : IRepository<Role, SQLServerContext>
    {

    }
    public class RoleRepo : Repository<Role, SQLServerContext>, IRoleRepo
    {
        public RoleRepo(IUnitOfWork<SQLServerContext> unitOfWork) : base(unitOfWork)
        {
        }
    }
}
