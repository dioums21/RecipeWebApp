using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace RecipeWebSite.Models
{
    public class Recipe
    {
        public int RecipeId { get; set; }
        [Required(ErrorMessage = "Please enter a recipe name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please enter a recipe description")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Please enter ingredients")]
        public string Ingredients{ get; set; }
        [Required(ErrorMessage = "Please enter chef's name")]
        public string Chef { get; set; }
        [Required(ErrorMessage = "Please enter time")]
        public int Time { get; set; }
        
    }
}
