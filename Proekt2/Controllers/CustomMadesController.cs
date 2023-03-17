using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Proekt2.Models
{
    public class CustomMadesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CustomMades
        public ActionResult Index()
        {
            return View(db.customMades.ToList());
        }

        public ActionResult PreBuiltPC()
        {
            return PartialView(db.customMades.ToList());
        }

        // GET: CustomMades/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomMade customMade = db.customMades.Find(id);
            if (customMade == null)
            {
                return HttpNotFound();
            }
            return View(customMade);
        }

        [Authorize(Roles = "Administrator, Seller")]
        // GET: CustomMades/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomMades/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Seller")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,ImgURL,Price,Processor,MotherBoard,Storage,PowerSupply,RAM,GraphicsCard,Case")] CustomMade customMade)
        {
            if (ModelState.IsValid)
            {
                db.customMades.Add(customMade);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(customMade);
        }

        [Authorize(Roles = "Administrator, Seller")]
        // GET: CustomMades/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomMade customMade = db.customMades.Find(id);
            if (customMade == null)
            {
                return HttpNotFound();
            }
            return View(customMade);
        }

        // POST: CustomMades/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [Authorize(Roles = "Administrator, Seller")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,ImgURL,Price,Processor,MotherBoard,Storage,PowerSupply,RAM,GraphicsCard,Case")] CustomMade customMade)
        {
            if (ModelState.IsValid)
            {
                db.Entry(customMade).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customMade);
        }

        [Authorize(Roles = "Administrator, Seller")]
        // GET: CustomMades/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomMade customMade = db.customMades.Find(id);
            if (customMade == null)
            {
                return HttpNotFound();
            }
            return View(customMade);
        }

        [Authorize(Roles = "Administrator, Seller")]
        // POST: CustomMades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CustomMade customMade = db.customMades.Find(id);
            db.customMades.Remove(customMade);
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
