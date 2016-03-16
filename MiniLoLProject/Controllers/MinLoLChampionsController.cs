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
    public class MinLoLChampionsController : Controller
    {
        private MinLoLChampsEntities db = new MinLoLChampsEntities();

        // GET: MinLoLChampions
        public ActionResult Index()
        {
            var minLoLChampions = db.MinLoLChampions.Include(m => m.MinLoLRole).Include(m => m.MinLoLUltimate);
            return View(minLoLChampions.ToList());
        }

        // GET: MinLoLChampions/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLChampion minLoLChampion = db.MinLoLChampions.Find(id);
            if (minLoLChampion == null)
            {
                return HttpNotFound();
            }
            return View(minLoLChampion);
        }

        // GET: MinLoLChampions/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.ChampRoleID = new SelectList(db.MinLoLRoles, "ChampRoleID", "RoleName");
            ViewBag.UltimateID = new SelectList(db.MinLoLUltimates, "UltimateID", "UltimateName");
            return View();
        }

        // POST: MinLoLChampions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Title,ChampIcon,ChampPic,ChampBio,ChampID,UltimateID,ChampRoleID")] MinLoLChampion minLoLChampion,
           IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {
                //empty strings
                string icon = "";
                string background = "";

                //get image file names 
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
                            return View(minLoLChampion);
                        }
                        if (ext == ".png")
                        {
                            icon = minLoLChampion.Name + ext;
                            file.SaveAs(Server.MapPath("~/Content/Champions/Icons/" + icon));
                           
                        }
                        else if (ext == ".jpg")
                        {
                            background = minLoLChampion.Name + ext;
                            file.SaveAs(Server.MapPath("~/Content/Champions/Pics/" + background));

                        }
                    }

                }



                ////add img values to champ object



                minLoLChampion.ChampIcon = icon;
                minLoLChampion.ChampPic = background;
                db.MinLoLChampions.Add(minLoLChampion);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ChampRoleID = new SelectList(db.MinLoLRoles, "ChampRoleID", "RoleName", minLoLChampion.ChampRoleID);
            ViewBag.UltimateID = new SelectList(db.MinLoLUltimates, "UltimateID", "UltimateName", minLoLChampion.UltimateID);
            return View(minLoLChampion);
        }

        // GET: MinLoLChampions/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLChampion minLoLChampion = db.MinLoLChampions.Find(id);
            string p1 = minLoLChampion.ChampIcon;
            string p2 = minLoLChampion.ChampPic;
          
            TempData["Icon"] = p1;
            TempData["Pic"] = p2;
            if (minLoLChampion == null)
            {
                return HttpNotFound();
            }
            ViewBag.ChampRoleID = new SelectList(db.MinLoLRoles, "ChampRoleID", "RoleName", minLoLChampion.ChampRoleID);
            ViewBag.UltimateID = new SelectList(db.MinLoLUltimates, "UltimateID", "UltimateName", minLoLChampion.UltimateID);
            return View(minLoLChampion);
        }

        // POST: MinLoLChampions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Name,Title,ChampIcon,ChampPic,ChampBio,ChampID,UltimateID,ChampRoleID")] MinLoLChampion minLoLChampion, IEnumerable<HttpPostedFileBase> files)
        {
            if (ModelState.IsValid)
            {

                string icon = (string)TempData["Icon"];
                string background = (string)TempData["Pic"];
                //get image file names 
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
                            return View(minLoLChampion);
                        }
                        if (ext == ".png")
                        {
                         icon = Guid.NewGuid() + ext;
                            file.SaveAs(Server.MapPath("~/Content/Champions/Icons/" + icon));
                           



                        }
                        else if (ext == ".jpg")
                        {
                            background = Guid.NewGuid() + ext;
                            file.SaveAs(Server.MapPath("~/Content/Champions/Pics/" + background));
                           


                        }
                    }
           
                  
                }

                minLoLChampion.ChampIcon = icon;
                minLoLChampion.ChampPic = background;
                ////add img values to champ object






                db.Entry(minLoLChampion).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ChampRoleID = new SelectList(db.MinLoLRoles, "ChampRoleID", "RoleName", minLoLChampion.ChampRoleID);
            ViewBag.UltimateID = new SelectList(db.MinLoLUltimates, "UltimateID", "UltimateName", minLoLChampion.UltimateID);
            return View(minLoLChampion);
        }

        // GET: MinLoLChampions/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MinLoLChampion minLoLChampion = db.MinLoLChampions.Find(id);
            if (minLoLChampion == null)
            {
                return HttpNotFound();
            }
            return View(minLoLChampion);
        }

        // POST: MinLoLChampions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MinLoLChampion minLoLChampion = db.MinLoLChampions.Find(id);
            db.MinLoLChampions.Remove(minLoLChampion);
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
