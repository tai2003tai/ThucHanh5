using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Library.Models;

namespace Library.Controllers
{
    public class SACHesController : Controller
    {
        private Model1 db = new Model1();

        // GET: SACHes
        public ActionResult Index()
        {
            var sACHes = db.SACHes.Include(s => s.CHINHANH).Include(s => s.DAUSACH);
            return View(sACHes.ToList());
        }

        // GET: SACHes/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // GET: SACHes/Create
        public ActionResult Create()
        {
            ViewBag.MaCN = new SelectList(db.CHINHANHs, "MaCN", "TenCN");
            ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenDS");
            return View();
        }

        // POST: SACHes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaSach,MaDS,MaCN,TrangThai")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.SACHes.Add(sACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaCN = new SelectList(db.CHINHANHs, "MaCN", "TenCN", sACH.MaCN);
            ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenDS", sACH.MaDS);
            return View(sACH);
        }

        // GET: SACHes/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaCN = new SelectList(db.CHINHANHs, "MaCN", "TenCN", sACH.MaCN);
            ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenDS", sACH.MaDS);
            return View(sACH);
        }

        // POST: SACHes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaSach,MaDS,MaCN,TrangThai")] SACH sACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaCN = new SelectList(db.CHINHANHs, "MaCN", "TenCN", sACH.MaCN);
            ViewBag.MaDS = new SelectList(db.DAUSACHes, "MaDS", "TenDS", sACH.MaDS);
            return View(sACH);
        }

        // GET: SACHes/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SACH sACH = db.SACHes.Find(id);
            if (sACH == null)
            {
                return HttpNotFound();
            }
            return View(sACH);
        }

        // POST: SACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SACH sACH = db.SACHes.Find(id);
            db.SACHes.Remove(sACH);
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
