using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniLoLProject.DAL;
using System.Collections;
using System.IO;

namespace MiniLoLProject.Controllers
{
    [Authorize(Roles = "Admin")]
    public class MinLoLUltimatesController : Controller
    {
        static Random rand;
        private MinLoLChampsEntities db = new MinLoLChampsEntities();

        // GET: MinLoLUltimates
        public ActionResult Index()
        {
            return View(db.MinLoLUltimates.ToList());
        }

        // GET: MinLoLUltimates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLUltimate minLoLUltimate = db.MinLoLUltimates.Find(id);
            if (minLoLUltimate == null)
            {
                return HttpNotFound();
            }
            return View(minLoLUltimate);
        }

        // GET: MinLoLUltimates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MinLoLUltimates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UltimateID,UltimateName,UltimateIcon,UltimatePic,UltimateDescription,UltimateCost")] MinLoLUltimate minLoLUltimate,
            IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                //empty strings
                string icon = "";
                string ultipic = "";
                foreach (var file in files)
                {
                    if (file != null)
                    {  //use the name to get the extension
                        string extcheck = file.FileName;
                        string ext = extcheck.Substring(extcheck.LastIndexOf('.'));
                        //black list malicious code
                        if (ext == ".exe" || ext == ".dll")
                        {
                            //could set the photoUrl to null before returning

                            //sends to the view before persisting to the structure
                            return View(minLoLUltimate);
                        }
                        if (ext == ".png")
                        {
                            icon = Guid.NewGuid() + ext;
                            file.SaveAs(Server.MapPath("~/Content/Ultimates/Icons/" + icon));

                        }
                        else if (ext == ".jpg")
                        {
                            ultipic = Guid.NewGuid() + ext;
                            file.SaveAs(Server.MapPath("~/Content/Ultimates/Pic/" + ultipic));

                        }
                    }

                }
                //add img values to object
             
                minLoLUltimate.UltimateIcon = icon;
                minLoLUltimate.UltimatePic = ultipic;
                db.MinLoLUltimates.Add(minLoLUltimate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(minLoLUltimate);
        }

        // GET: MinLoLUltimates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLUltimate minLoLUltimate = db.MinLoLUltimates.Find(id);

            string p1 = minLoLUltimate.UltimateIcon;
            string p2 = minLoLUltimate.UltimatePic;

            TempData["Icon"] = p1;
            TempData["Pic"] = p2;

            if (minLoLUltimate == null)
            {
                return HttpNotFound();
            }
            return View(minLoLUltimate);
        }

        // POST: MinLoLUltimates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UltimateID,UltimateName,UltimateIcon,UltimatePic,UltimateDescription,UltimateCost")] MinLoLUltimate minLoLUltimate, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                string icon = (string)TempData["Icon"];
                string ultipic = (string)TempData["Pic"];
                foreach (var file in files)
                {
                    if (file != null)
                    {  //use the name to get the extension
                        string extcheck = file.FileName;
                        string ext = extcheck.Substring(extcheck.LastIndexOf('.'));
                        //black list malicious code
                        if (ext == ".exe" || ext == ".dll")
                        {
                            //could set the photoUrl to null before returning

                            //sends to the view before persisting to the structure
                            return View(minLoLUltimate);
                        }
                        if (ext == ".png")
                        {
                            icon = Guid.NewGuid() + ext;
                            file.SaveAs(Server.MapPath("~/Content/Ultimates/Icons/" + icon));

                        }
                        else if (ext == ".jpg")
                        {
                            ultipic = Guid.NewGuid() + ext;
                            file.SaveAs(Server.MapPath("~/Content/Ultimates/Pic/" + ultipic));

                        }
                    }

                }
                //add img values to object

                minLoLUltimate.UltimateIcon = icon;
                minLoLUltimate.UltimatePic = ultipic;

                db.Entry(minLoLUltimate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(minLoLUltimate);
        }

        // GET: MinLoLUltimates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLUltimate minLoLUltimate = db.MinLoLUltimates.Find(id);
            if (minLoLUltimate == null)
            {
                return HttpNotFound();
            }
            return View(minLoLUltimate);
        }

        // POST: MinLoLUltimates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinLoLUltimate minLoLUltimate = db.MinLoLUltimates.Find(id);
            db.MinLoLUltimates.Remove(minLoLUltimate);
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
