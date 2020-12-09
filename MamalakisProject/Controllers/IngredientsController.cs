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
    public class IngredientsController : Controller
    {
        private MamalakisDBContext db = new MamalakisDBContext();

        // GET: Ingredients
        public ActionResult Index()
        {
            ViewBag.IngredientTypeId = new SelectList(db.IngredientTypes, "Id", "IngredientTypeName");
            return View(db.Ingredients.Include(x=>x.IngrentientType).ToList().OrderBy(x=>x.Name));
        }

        // GET: Ingredients/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Include(x => x.IngrentientType).Include(x=>x.IngredientsPerRecipeId.Select(i=>i.Recipe)).Include(x=>x.IngredientsPerRecipeId.Select(i=>i.Metric)). FirstOrDefault(x => x.Id == id);

            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // GET: Ingredients/Create
        public ActionResult Create()
        {
            ViewBag.IngredientTypeId = new SelectList(db.IngredientTypes, "Id", "IngredientTypeName");
            return View();
        }

        // POST: Ingredients/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IngredientTypeId")] Ingredient ingredient)
        {
            ViewBag.IngredientTypeId = new SelectList(db.IngredientTypes, "Id", "IngredientTypeName");
            if (ModelState.IsValid)
            {
                db.Ingredients.Add(ingredient);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ingredient);
        }

        // GET: Ingredients/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.IngredientTypeId = new SelectList(db.IngredientTypes, "Id", "IngredientTypeName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingredient ingredient = db.Ingredients.Include(x => x.IngrentientType).FirstOrDefault(x=>x.Id==id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IngredientTypeId")] Ingredient ingredient)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredient).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientTypeId = new SelectList(db.IngredientTypes, "Id", "IngredientTypeName");
            return View(ingredient);
        }

        // GET: Ingredients/Delete/5
        public ActionResult Delete(int? id)
        {
            ViewBag.IngredientTypeId = new SelectList(db.IngredientTypes, "Id", "IngredientTypeName");
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            
            Ingredient ingredient = db.Ingredients.Include(x => x.IngrentientType).FirstOrDefault(x => x.Id == id);
            if (ingredient == null)
            {
                return HttpNotFound();
            }
            return View(ingredient);
        }

        // POST: Ingredients/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingredient ingredient = db.Ingredients.Find(id);
            db.Ingredients.Remove(ingredient);
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
