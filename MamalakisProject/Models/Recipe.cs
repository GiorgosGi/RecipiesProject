using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace MamalakisProject.Models
{
    public class Recipe
    {
        public int Id { get; set; }
        [Display(Name="Recipe Name")]
        public string Name { get; set; }
        [Display(Name = "Creator")]
        public int CreatorId { get; set; }
        public Creator Creator {get; set;}
        public List<IngredientsPerRecipe> IngredientsPerRecipe { get; set; } 
    }
}