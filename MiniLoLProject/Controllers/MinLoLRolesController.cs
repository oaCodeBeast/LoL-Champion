using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniLoLProject.DAL;

namespace MiniLoLProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MinLoLRolesController : Controller
    {
        private MinLoLChampsEntities db = new MinLoLChampsEntities();

        // GET: MinLoLRoles
        public ActionResult Index()
        {
            return View(db.MinLoLRoles.ToList());
        }

        // GET: MinLoLRoles/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLRole minLoLRole = db.MinLoLRoles.Find(id);
            if (minLoLRole == null)
            {
                return HttpNotFound();
            }
            return View(minLoLRole);
        }

        // GET: MinLoLRoles/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MinLoLRoles/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ChampRoleID,RoleName,RoleDescription")] MinLoLRole minLoLRole)
        {
            if (ModelState.IsValid)
            {
                db.MinLoLRoles.Add(minLoLRole);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(minLoLRole);
        }

        // GET: MinLoLRoles/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLRole minLoLRole = db.MinLoLRoles.Find(id);
            if (minLoLRole == null)
            {
                return HttpNotFound();
            }
            return View(minLoLRole);
        }

        // POST: MinLoLRoles/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ChampRoleID,RoleName,RoleDescription")] MinLoLRole minLoLRole)
        {
            if (ModelState.IsValid)
            {
                db.Entry(minLoLRole).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(minLoLRole);
        }

        // GET: MinLoLRoles/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLRole minLoLRole = db.MinLoLRoles.Find(id);
            if (minLoLRole == null)
            {
                return HttpNotFound();
            }
            return View(minLoLRole);
        }

        // POST: MinLoLRoles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinLoLRole minLoLRole = db.MinLoLRoles.Find(id);
            db.MinLoLRoles.Remove(minLoLRole);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
