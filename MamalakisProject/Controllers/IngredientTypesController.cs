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
    public class IngredientTypesController : Controller
    {
        private MamalakisDBContext db = new MamalakisDBContext();

        // GET: IngredientTypes
        public ActionResult Index()
        {
            return View(db.IngredientTypes.ToList());
        }

        // GET: IngredientTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientType ingredientType = db.IngredientTypes.Find(id);
            if (ingredientType == null)
            {
                return HttpNotFound();
            }
            return View(ingredientType);
        }

        // GET: IngredientTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IngredientTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,IngredientTypeName")] IngredientType ingredientType)
        {
            if (ModelState.IsValid)
            {
                db.IngredientTypes.Add(ingredientType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredientType);
        }

        // GET: IngredientTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientType ingredientType = db.IngredientTypes.Find(id);
            if (ingredientType == null)
            {
                return HttpNotFound();
            }
            return View(ingredientType);
        }

        // POST: IngredientTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,IngredientTypeName")] IngredientType ingredientType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredientType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ingredientType);
        }

        // GET: IngredientTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientType ingredientType = db.IngredientTypes.Find(id);
            if (ingredientType == null)
            {
                return HttpNotFound();
            }
            return View(ingredientType);
        }

        // POST: IngredientTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngredientType ingredientType = db.IngredientTypes.Find(id);
            db.IngredientTypes.Remove(ingredientType);
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
