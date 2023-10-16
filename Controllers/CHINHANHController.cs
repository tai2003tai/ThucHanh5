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
    public class CHINHANHController : Controller
    {
        private Model1 db = new Model1();

        // GET: CHINHANH
        public ActionResult Index()
        {
            return View(db.CHINHANHs.ToList());
        }

        // GET: CHINHANH/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            if (cHINHANH == null)
            {
                return HttpNotFound();
            }
            return View(cHINHANH);
        }

        // GET: CHINHANH/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CHINHANH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaCN,TenCN,DiaChi")] CHINHANH cHINHANH)
        {
            if (ModelState.IsValid)
            {
                db.CHINHANHs.Add(cHINHANH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cHINHANH);
        }

        // GET: CHINHANH/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            if (cHINHANH == null)
            {
                return HttpNotFound();
            }
            return View(cHINHANH);
        }

        // POST: CHINHANH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaCN,TenCN,DiaChi")] CHINHANH cHINHANH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHINHANH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cHINHANH);
        }

        // GET: CHINHANH/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            if (cHINHANH == null)
            {
                return HttpNotFound();
            }
            return View(cHINHANH);
        }

        // POST: CHINHANH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHINHANH cHINHANH = db.CHINHANHs.Find(id);
            db.CHINHANHs.Remove(cHINHANH);
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
