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

        [HttpGet]
        public ActionResult Updateuser(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            CrudContext db = new CrudContext();
            var output = db.user.Single(x => x.id == id);
            return View(output);
        }

        [HttpPost]
        public ActionResult Updateusers(UserModel user)
        {
            if (ModelState.IsValid)
            {
                CrudContext db = new CrudContext();
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                ViewBag.Message = user.UserName + " successfully edited.";
                return RedirectToAction("Retrive");
            }
            return View("Retrive");
        }

        public ActionResult ShowDetail(string id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }
            CrudContext db = new CrudContext();
            var output = db.user.Single(x => x.id == id);

            if (output == null)
            {
                return HttpNotFound();
            }
            return View(output);
        }

    }
}