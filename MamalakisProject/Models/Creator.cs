using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MamalakisProject.Models
{
    public class Creator
    {
        public int Id { get; set; }
        [Display(Name="Creator Name")]
        public string Name { get; set; }
        public List<Recipe> Recipes { get; set; }  
    }
}