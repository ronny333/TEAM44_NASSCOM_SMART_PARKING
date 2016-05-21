using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SmartParking.Models;

namespace SmartParking.Controllers
{
    public class ParkingSlotsController : Controller
    {
        private SmartParkingEntities1 db = new SmartParkingEntities1();

        // GET: ParkingSlots
        public ActionResult Index()
        {
            var parkingSlots = db.ParkingSlots.Include(p => p.Owner);
            return View(parkingSlots.ToList());
        }

        // GET: ParkingSlots/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSlot parkingSlot = db.ParkingSlots.Find(id);
            if (parkingSlot == null)
            {
                return HttpNotFound();
            }
            return View(parkingSlot);
        }

        // GET: ParkingSlots/Create
        public ActionResult Create()
        {
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerName");
            return View();
        }

        // POST: ParkingSlots/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ParkingSlotID,OwnerID,ParkingSlotAddress,SlotNumber,AvailableStartDate,AvailableEndDate,value,Latitude,Longitude,StartTime,EndTime")] ParkingSlot parkingSlot)
        {
            if (ModelState.IsValid)
            {
                db.ParkingSlots.Add(parkingSlot);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerName", parkingSlot.OwnerID);
            return View(parkingSlot);
        }

        // GET: ParkingSlots/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSlot parkingSlot = db.ParkingSlots.Find(id);
            if (parkingSlot == null)
            {
                return HttpNotFound();
            }
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerName", parkingSlot.OwnerID);
            return View(parkingSlot);
        }

        // POST: ParkingSlots/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ParkingSlotID,OwnerID,ParkingSlotAddress,SlotNumber,AvailableStartDate,AvailableEndDate,value,Latitude,Longitude,StartTime,EndTime")] ParkingSlot parkingSlot)
        {
            if (ModelState.IsValid)
            {
                db.Entry(parkingSlot).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.OwnerID = new SelectList(db.Owners, "OwnerID", "OwnerName", parkingSlot.OwnerID);
            return View(parkingSlot);
        }

        // GET: ParkingSlots/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ParkingSlot parkingSlot = db.ParkingSlots.Find(id);
            if (parkingSlot == null)
            {
                return HttpNotFound();
            }
            return View(parkingSlot);
        }

        // POST: ParkingSlots/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ParkingSlot parkingSlot = db.ParkingSlots.Find(id);
            db.ParkingSlots.Remove(parkingSlot);
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
