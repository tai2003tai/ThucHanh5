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
    public class DOCGIAsController : Controller
    {
        private Model1 db = new Model1();

        // GET: DOCGIAs
        public ActionResult Index()
        {
            var dOCGIAs = db.DOCGIAs.Include(d => d.LOAIDOCGIA);
            return View(dOCGIAs.ToList());
        }

        // GET: DOCGIAs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(dOCGIA);
        }

        // GET: DOCGIAs/Create
        public ActionResult Create()
        {
            ViewBag.MaLoaiDG = new SelectList(db.LOAIDOCGIAs, "MaLoaiDG", "TenLoaiDG");
            return View();
        }

        // POST: DOCGIAs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,HoTenDG,CMND,SDT,DiaChi,Email,UserName,HashPass,MaLoaiDG,TrangThai")] DOCGIA dOCGIA)
        {
            if (ModelState.IsValid)
            {
                db.DOCGIAs.Add(dOCGIA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaLoaiDG = new SelectList(db.LOAIDOCGIAs, "MaLoaiDG", "TenLoaiDG", dOCGIA.MaLoaiDG);
            return View(dOCGIA);
        }

        // GET: DOCGIAs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaLoaiDG = new SelectList(db.LOAIDOCGIAs, "MaLoaiDG", "TenLoaiDG", dOCGIA.MaLoaiDG);
            return View(dOCGIA);
        }

        // POST: DOCGIAs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDG,HoTenDG,CMND,SDT,DiaChi,Email,UserName,HashPass,MaLoaiDG,TrangThai")] DOCGIA dOCGIA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dOCGIA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaLoaiDG = new SelectList(db.LOAIDOCGIAs, "MaLoaiDG", "TenLoaiDG", dOCGIA.MaLoaiDG);
            return View(dOCGIA);
        }

        // GET: DOCGIAs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            if (dOCGIA == null)
            {
                return HttpNotFound();
            }
            return View(dOCGIA);
        }

        // POST: DOCGIAs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            DOCGIA dOCGIA = db.DOCGIAs.Find(id);
            db.DOCGIAs.Remove(dOCGIA);
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
