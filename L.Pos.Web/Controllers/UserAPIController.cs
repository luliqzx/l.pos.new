using L.Pos.DataAccess.Common;
using L.Pos.DataAccess.Repository;
using L.Pos.Domain.Common;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace L.Pos.Web.Controllers
{
    public class UserAPIController : ApiController
    {
        private IUserRepo userSQLRepo;
        private IRoleRepo RoleRepo;

        public UserAPIController(IUserRepo _userSQLRepo, IRoleRepo _RoleRepo)
        {
            RoleRepo = _RoleRepo;
            userSQLRepo = _userSQLRepo;
        }

        public Response GetList()
        {
            Response response = new Response();
            Stopwatch sw = new Stopwatch();
            response.Message = "";
            response.MessageCode = MessageCode.SUCCESS;
            sw.Start();
            try
            {
                IList<User> lstUser = userSQLRepo.GetAll().ToList();
                response.Data = lstUser;
            }
            catch (Exception ex)
            {
                response.MessageCode = MessageCode.FAIL;
                response.Message = ex.Message;
            }
            sw.Stop();
            response.ResponseTime = sw.Elapsed.TotalSeconds;
            return response;
        }
    }
}
