using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MamalakisProject.Models
{
    public class MamalakisDBContext : DbContext
    {
        public DbSet<Creator> Creators { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Metric> Metrics { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<IngredientsPerRecipe> IngredientsPerRecipies { get; set; }
        public DbSet<IngredientType> IngredientTypes { get; set; }
    }    
}