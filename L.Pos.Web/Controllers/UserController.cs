using L.Pos.DataAccess.Common;
using L.Pos.DataAccess.Repository;
using L.Pos.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace L.Pos.Web.Controllers
{
    public class UserController : Controller
    {
        private IUserRepo userSQLRepo;
        private IRoleRepo RoleRepo;
        private IRepository<User, MySQLContext> userMySQLRepo;

        public UserController(IUserRepo _userSQLRepo, IRoleRepo _RoleRepo, IRepository<User, MySQLContext> _userMySQLRepo)
        {
            RoleRepo = _RoleRepo;
            userSQLRepo = _userSQLRepo;
            userMySQLRepo = _userMySQLRepo;
        }
        // GET: User
        public ActionResult Index()
        {
            IList<User> lstUser = userMySQLRepo.GetAll().ToList();
            return View(lstUser);
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            try
            {
                // TODO: Add insert logic here

                User usr = new User();
                usr = user;
                usr.CreateBy = "user";
                usr.CreateDate = DateTime.Now;
                usr.UpdateBy = "user";
                usr.UpdateDate = DateTime.Now;
                userSQLRepo.Create(usr);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            User user = userSQLRepo.GetBy(x => x.ID == id);
            return View(user);
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User _user)
        {
            try
            {
                // TODO: Add update logic here
                userSQLRepo.BeginTransaction();
                User user = userSQLRepo.GetBy(x => x.ID == id);
                user.Username = _user.Username;
                user.Password = _user.Password;
                userSQLRepo.Update(user);

                User user2 = userSQLRepo.GetBy(x => x.ID == id);
                //userSQLRepo.Delete(user2);

                //Role role = RoleRepo.GetBy(x => x.Name == "test");
                //if (role == null)
                //{
                //    RoleRepo.BeginTransaction();
                //    role = new Role();
                //    role.Name = "test";
                //    role.ID = "test";
                //    RoleRepo.Create(role);
                //    RoleRepo.Commit();
                //}

                ////role = RoleRepo.GetBy(x => x.Name == "test");
                //if (role != null)
                //{
                //    RoleRepo.BeginTransaction();
                //    role = new Role();
                //    role.Name = "test123123";
                //    role.ID = "test";
                //    RoleRepo.Update(role);
                //    RoleRepo.Commit();
                //}

                //role = RoleRepo.GetBy(x => x.Name == "test");
                //if (role != null)
                //{
                //    RoleRepo.BeginTransaction();
                //    RoleRepo.Delete(role);
                //    RoleRepo.Commit();
                //}
                userSQLRepo.Commit();
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
