using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WA_Food_Coalition.Models;

namespace WA_Food_Coalition.Controllers
{
    public class ContactInfoController : Controller
    {
        private ContactInfoDBContext db = new ContactInfoDBContext();

        // GET: /ContactInfo/
        public ActionResult Index()
        {
            return View(db.ContactInfos.ToList());
        }

        // GET: /ContactInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactinfo = db.ContactInfos.Find(id);
            if (contactinfo == null)
            {
                return HttpNotFound();
            }
            return View(contactinfo);
        }

        // GET: /ContactInfo/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /ContactInfo/Create
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ContactInfo contactinfo)
        {
            if (ModelState.IsValid)
            {
                db.ContactInfos.Add(contactinfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactinfo);
        }

        // GET: /ContactInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactinfo = db.ContactInfos.Find(id);
            if (contactinfo == null)
            {
                return HttpNotFound();
            }
            return View(contactinfo);
        }

        // POST: /ContactInfo/Edit/5
		// To protect from over posting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		// 
		// Example: public ActionResult Update([Bind(Include="ExampleProperty1,ExampleProperty2")] Model model)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ContactInfo contactinfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactinfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactinfo);
        }

        // GET: /ContactInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactInfo contactinfo = db.ContactInfos.Find(id);
            if (contactinfo == null)
            {
                return HttpNotFound();
            }
            return View(contactinfo);
        }

        // POST: /ContactInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactInfo contactinfo = db.ContactInfos.Find(id);
            db.ContactInfos.Remove(contactinfo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
