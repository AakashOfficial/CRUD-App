using CRUD_App.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRUD_App.Controllers
{
    public class UsersController : Controller
    {
        // GET: Users
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel account)
        {
            if (ModelState.IsValid)
            {
                using (CrudContext db = new CrudContext())
                {
                    db.user.Add(account);
                    db.SaveChanges();
                }

                ModelState.Clear();

                ViewBag.Message = account.UserName + " successfully created.";
            }
            return View();
        }

        public ActionResult Retrive(UserModel user)
        {
            using (CrudContext db = new CrudContext())
            {
                var output = db.user.ToList();
                return View(output);
            }
        }

    }
}