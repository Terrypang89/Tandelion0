using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tandelion0.DAL;
using Tandelion0.Models;

namespace Tandelion0.Controllers
{
    public class TendersController : Controller
    {
        private StoreContext db = new StoreContext();

        // GET: Tenders
        public ActionResult Index()
        {
            var tendersDB = db.tendersDB.Include(t => t.Trade);
            return View(tendersDB.ToList());
        }

        // GET: Tenders/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tendersDB.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // GET: Tenders/Create
        public ActionResult Create()
        {
            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType");
            return View();
        }

        // POST: Tenders/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,CompanyName,Status,PIC,Designation,HP,ContactNo,TradeID")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.tendersDB.Add(tender);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType", tender.TradeID);
            return View(tender);
        }

        // GET: Tenders/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tendersDB.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType", tender.TradeID);
            return View(tender);
        }

        // POST: Tenders/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,CompanyName,Status,PIC,Designation,HP,ContactNo,TradeID")] Tender tender)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tender).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TradeID = new SelectList(db.tradesDB, "ID", "TradeType", tender.TradeID);
            return View(tender);
        }

        // GET: Tenders/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tender tender = db.tendersDB.Find(id);
            if (tender == null)
            {
                return HttpNotFound();
            }
            return View(tender);
        }

        // POST: Tenders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tender tender = db.tendersDB.Find(id);
            db.tendersDB.Remove(tender);
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
