using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MamalakisProject.Models
{
    public class IngredientType
    {
        public int Id { get; set; }
        [Display(Name="Ingredient Type")]
        public string IngredientTypeName { get; set; }

    }
}