using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TaskHospital.Models;

namespace TaskHospital.Controllers
{
    public class PatientsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Patients
        public ActionResult Index()
        {
            return View(db.Patients.ToList());
        }

        // GET: Patients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // GET: Patients/Create
        public ActionResult Create()
        {
            ViewBag.TypePatient = new SelectList(db.TypePatients, "ID", "Name ");
            return View();
        }

        // POST: Patients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Patient patient,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                var x = (patient.PatientCode).ToString();
                DateTime date = DateTime.Now;
                string day = (date.Day.ToString()).Length == 1 ? "0" + date.Day.ToString() : date.Day.ToString();
                string month = (date.Month.ToString()).Length == 1 ? "0" + date.Month.ToString() : date.Month.ToString();
                string NewCode = x.Length == 1 ? "000" + x : (x.Length == 2 ? "00" + x : (x.Length == 3 ? "0" + x : x));
               
                NewCode = (NewCode + day + month + date.Year.ToString());
                patient.PatientCode =  Convert.ToInt32(  NewCode);
                if (upload != null)
                {
                    string fileName = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                    upload.SaveAs(fileName);
                    patient.PatientImage = upload.FileName;
                }
               
                db.Patients.Add(patient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypePatient = new SelectList(db.TypePatients, "ID", "Name ");

            return View(patient);
        }

        // GET: Patients/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            ViewBag.TypePatient = new SelectList(db.TypePatients, "ID", "Name ");

            return View(patient);
        }

        // POST: Patients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( Patient patient ,HttpPostedFileBase upload)
        {
            if (ModelState.IsValid)
            {
                string fileName = Path.Combine(Server.MapPath("~/Uploads"), upload.FileName);
                upload.SaveAs(fileName);
                patient.PatientImage = upload.FileName;
                db.Entry(patient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TypePatient = new SelectList(db.TypePatients, "ID", "Name ");
            return View(patient);
        }

        // GET: Patients/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Patient patient = db.Patients.Find(id);
            if (patient == null)
            {
                return HttpNotFound();
            }
            return View(patient);
        }

        // POST: Patients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Patient patient = db.Patients.Find(id);
            db.Patients.Remove(patient);
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
