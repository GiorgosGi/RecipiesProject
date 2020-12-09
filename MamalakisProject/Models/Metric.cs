using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MamalakisProject.Models
{
    public class Metric
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string ShortName { get; set; }
        public List<IngredientsPerRecipe> IngredientsPerRecipeId { get; set; }
    }
}