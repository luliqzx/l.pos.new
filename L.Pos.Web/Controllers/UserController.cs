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
        private IRepository<User, SQLServerContext> userSQLRepo;
        private IRepository<User, MySQLContext> userMySQLRepo;

        public UserController(IRepository<User, SQLServerContext> _userSQLRepo, IRepository<User, MySQLContext> _userMySQLRepo)
        {
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
            return View();
        }

        // POST: User/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
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
