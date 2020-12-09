using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MamalakisProject.Models;

namespace MamalakisProject.Controllers
{
    public class CreatorsController : Controller
    {
        private MamalakisDBContext db = new MamalakisDBContext();

        // GET: Creators
        public ActionResult Index()
        {
            return View(db.Creators.ToList());
        }

        // GET: Creators/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Creator creator = db.Creators.Include(x => x.Recipes).FirstOrDefault(x => x.Id == id);
            if (creator == null)
            {
                return HttpNotFound();
            }
            return View(creator);
        }

        // GET: Creators/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Creators/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name")] Creator creator)
        {
            if (ModelState.IsValid)
            {
                db.Creators.Add(creator);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(creator);
        }

        // GET: Creators/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Creator creator = db.Creators.Include(x => x.Recipes).FirstOrDefault(x => x.Id == id);
            if (creator == null)
            {
                return HttpNotFound();
            }
            return View(creator);
        }

        // POST: Creators/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] Creator creator)
        {
            if (ModelState.IsValid)
            {
                db.Entry(creator).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(creator);
        }

        // GET: Creators/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Creator creator = db.Creators.Include(x => x.Recipes).FirstOrDefault(x => x.Id == id);
            if (creator == null)
            {
                return HttpNotFound();
            }
            return View(creator);
        }

        // POST: Creators/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Creator creator = db.Creators.Include(x => x.Recipes).FirstOrDefault(x => x.Id == id);
            db.Creators.Remove(creator);
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
