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
    public class MUONSACHController : Controller
    {
        private Model1 db = new Model1();

        // GET: MUONSACH
        public ActionResult Index()
        {
            var mUONSACHes = db.MUONSACHes.Include(m => m.DOCGIA).Include(m => m.SACH);
            return View(mUONSACHes.ToList());
        }

        // GET: MUONSACH/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUONSACH mUONSACH = db.MUONSACHes.Find(id);
            if (mUONSACH == null)
            {
                return HttpNotFound();
            }
            return View(mUONSACH);
        }

        // GET: MUONSACH/Create
        public ActionResult Create()
        {
            ViewBag.MaDG = new SelectList(db.DOCGIAs, "MaDG", "HoTenDG");
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TrangThai");
            return View();
        }

        // POST: MUONSACH/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MaDG,MaSach,NgayMuon,NgayDenHanTra,TinhTrang")] MUONSACH mUONSACH)
        {
            if (ModelState.IsValid)
            {
                db.MUONSACHes.Add(mUONSACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MaDG = new SelectList(db.DOCGIAs, "MaDG", "HoTenDG", mUONSACH.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TrangThai", mUONSACH.MaSach);
            return View(mUONSACH);
        }

        // GET: MUONSACH/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUONSACH mUONSACH = db.MUONSACHes.Find(id);
            if (mUONSACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.MaDG = new SelectList(db.DOCGIAs, "MaDG", "HoTenDG", mUONSACH.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TrangThai", mUONSACH.MaSach);
            return View(mUONSACH);
        }

        // POST: MUONSACH/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MaDG,MaSach,NgayMuon,NgayDenHanTra,TinhTrang")] MUONSACH mUONSACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(mUONSACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MaDG = new SelectList(db.DOCGIAs, "MaDG", "HoTenDG", mUONSACH.MaDG);
            ViewBag.MaSach = new SelectList(db.SACHes, "MaSach", "TrangThai", mUONSACH.MaSach);
            return View(mUONSACH);
        }

        // GET: MUONSACH/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MUONSACH mUONSACH = db.MUONSACHes.Find(id);
            if (mUONSACH == null)
            {
                return HttpNotFound();
            }
            return View(mUONSACH);
        }

        // POST: MUONSACH/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            MUONSACH mUONSACH = db.MUONSACHes.Find(id);
            db.MUONSACHes.Remove(mUONSACH);
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
