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
    public class IngredientsPerRecipesController : Controller
    {
        private MamalakisDBContext db = new MamalakisDBContext();

        // GET: IngredientsPerRecipes
        public ActionResult Index()
        {
            var ingredientsPerRecipies = db.IngredientsPerRecipies.Include(i => i.Ingredients).Include(i => i.Metric).Include(i => i.Recipe);
            return View(ingredientsPerRecipies.ToList());
        }

        // GET: IngredientsPerRecipes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientsPerRecipe ingredientsPerRecipe = db.IngredientsPerRecipies.Find(id);
            if (ingredientsPerRecipe == null)
            {
                return HttpNotFound();
            }
            return View(ingredientsPerRecipe);
        }

        // GET: IngredientsPerRecipes/Create
        public ActionResult Create()
        {
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name");
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "Name");
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name");
            return View();
        }

        // POST: IngredientsPerRecipes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RecipeId,IngredientId,MetricId,Quantity")] IngredientsPerRecipe ingredientsPerRecipe)
        {
            if (ModelState.IsValid)
            {
                db.IngredientsPerRecipies.Add(ingredientsPerRecipe);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", ingredientsPerRecipe.IngredientId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "Name", ingredientsPerRecipe.MetricId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name", ingredientsPerRecipe.RecipeId);
            return View(ingredientsPerRecipe);
        }

        // GET: IngredientsPerRecipes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientsPerRecipe ingredientsPerRecipe = db.IngredientsPerRecipies.Find(id);
            if (ingredientsPerRecipe == null)
            {
                return HttpNotFound();
            }
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", ingredientsPerRecipe.IngredientId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "Name", ingredientsPerRecipe.MetricId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name", ingredientsPerRecipe.RecipeId);
            return View(ingredientsPerRecipe);
        }

        // POST: IngredientsPerRecipes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RecipeId,IngredientId,MetricId,Quantity")] IngredientsPerRecipe ingredientsPerRecipe)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingredientsPerRecipe).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IngredientId = new SelectList(db.Ingredients, "Id", "Name", ingredientsPerRecipe.IngredientId);
            ViewBag.MetricId = new SelectList(db.Metrics, "Id", "Name", ingredientsPerRecipe.MetricId);
            ViewBag.RecipeId = new SelectList(db.Recipes, "Id", "Name", ingredientsPerRecipe.RecipeId);
            return View(ingredientsPerRecipe);
        }

        // GET: IngredientsPerRecipes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IngredientsPerRecipe ingredientsPerRecipe = db.IngredientsPerRecipies.Find(id);
            if (ingredientsPerRecipe == null)
            {
                return HttpNotFound();
            }
            return View(ingredientsPerRecipe);
        }

        // POST: IngredientsPerRecipes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IngredientsPerRecipe ingredientsPerRecipe = db.IngredientsPerRecipies.Find(id);
            db.IngredientsPerRecipies.Remove(ingredientsPerRecipe);
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
