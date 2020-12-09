using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MamalakisProject.Models
{
    public class Ingredient
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int IngredientTypeId { get; set; }
        public IngredientType IngrentientType { get; set; }
        public List<IngredientsPerRecipe> IngredientsPerRecipeId { get; set; }
    }
}