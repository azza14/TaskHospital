using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskHospital.Models;

namespace TaskHospital.Controllers
{
    public class TypePatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: TypePatients
        public ActionResult Index()
        {
            return View(db.TypePatients.ToList());
        }

        // GET: TypePatients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypePatient typePatient = db.TypePatients.Find(id);
            if (typePatient == null)
            {
                return HttpNotFound();
            }
            return View(typePatient);
        }

        // GET: TypePatients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TypePatients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Name")] TypePatient typePatient)
        {
            if (ModelState.IsValid)
            {
                db.TypePatients.Add(typePatient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(typePatient);
        }

        // GET: TypePatients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypePatient typePatient = db.TypePatients.Find(id);
            if (typePatient == null)
            {
                return HttpNotFound();
            }
            return View(typePatient);
        }

        // POST: TypePatients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Name")] TypePatient typePatient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(typePatient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(typePatient);
        }

        // GET: TypePatients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TypePatient typePatient = db.TypePatients.Find(id);
            if (typePatient == null)
            {
                return HttpNotFound();
            }
            return View(typePatient);
        }

        // POST: TypePatients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TypePatient typePatient = db.TypePatients.Find(id);
            db.TypePatients.Remove(typePatient);
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
