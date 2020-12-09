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
    public class RecipesController : Controller
    {
        private MamalakisDBContext db = new MamalakisDBContext();

        // GET: Recipes
        public ActionResult Index()
        {
            var recipes = db.Recipes.Include(r => r.Creator);
            return View(recipes.ToList());
        }

        // GET: Recipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var result = (from a in db.IngredientsPerRecipies
            //              join h in db.Ingredients on a.IngredientId equals h.Id
            //              join c in db.Metrics on a.MetricId equals c.Id
            //              select new
            //              {
            //                  a.IngredientId,
            //                  a.Ingredients,
            //                  a.RecipeId,
            //                  a.Quantity,
            //                  a.MetricId,
            //                  a.Metric
            //              }
            
            Recipe recipe = db.Recipes.Include(x => x.Creator).
                Include(x=>x.IngredientsPerRecipe.Select(i=>i.Ingredients)).
                Include(x => x.IngredientsPerRecipe.Select(i => i.Metric)).
                FirstOrDefault(x => x.Id == id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // GET: Recipes/Create
        public ActionResult Create()
        {
            ViewBag.CreatorId = new SelectList(db.Creators, "Id", "Name");
            return View();
        }

        // POST: Recipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,CreatorId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Recipes.Add(recipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CreatorId = new SelectList(db.Creators, "Id", "Name", recipe.CreatorId);
            return View(recipe);
        }

        // GET: Recipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Find(id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.CreatorId = new SelectList(db.Creators, "Id", "Name", recipe.CreatorId);
            return View(recipe);
        }

        // POST: Recipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,CreatorId")] Recipe recipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(recipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CreatorId = new SelectList(db.Creators, "Id", "Name", recipe.CreatorId);
            return View(recipe);
        }

        // GET: Recipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Recipe recipe = db.Recipes.Include(x => x.Creator).FirstOrDefault(x => x.Id == id);
            if (recipe == null)
            {
                return HttpNotFound();
            }
            return View(recipe);
        }

        // POST: Recipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Recipe recipe = db.Recipes.Include(x => x.Creator).FirstOrDefault(x => x.Id == id);
            db.Recipes.Remove(recipe);
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
