using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeWebSite.Models;
using Microsoft.AspNetCore.Authorization;

namespace RecipeWebSite.Controllers
{
    [Authorize]
    public class CrudController : Controller
    {
        private IRecipeRepository repository;

        public CrudController(IRecipeRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public ViewResult AddRecipe()
        {
            return View();
        }
        [HttpPost]
        public IActionResult AddRecipe(Recipe recipe)
        {
            //List <string> ingredients = recipe.Ingredients;
            //string [] splitIngredients = recipe.Ingredients.Split(',');
            // recipe.Ingredients.Clear(); // if ididn't clear it at first, the first ingredient displayed would be the full list.

            /*
             I was having trouble displaying mulitple ingredients from recipes
             that were being added to the repository. This allowed me to take
             the one list item it WAS receiving, split it up and add every 
             ingredient individually. Please let me know if there was a better
             way haha!
             */
            /*
            foreach (var ing in splitIngredients)
            {
                recipe.Ingredients.Add(ing);
            }*/

            repository.SaveRecipe(recipe);
            TempData["message"] = $"{recipe.Name} was added!";
            return RedirectToAction("RecipeList", "Home");
        }
        public ViewResult ViewRecipe(int id)
        {


            Recipe recipe = repository.Recipes.Where(r => r.RecipeId == id).FirstOrDefault();
            return View(recipe);
        }

        
        public ViewResult EditRecipe(int recipeId) => View(repository.Recipes.FirstOrDefault(r => r.RecipeId == recipeId));

        [HttpPost]
        public IActionResult EditRecipe(Recipe recipe)
        {

            if (ModelState.IsValid)
            {
                repository.SaveRecipe(recipe);
                TempData["message"] = $"{recipe.Name} has been saved!";
                return RedirectToAction("RecipeList", "Home");
            }
            else
            {
                return View(recipe);
            }
                
            
        }

        [HttpPost]
        public IActionResult DeleteRecipe(int RecipeId)
        {
            Recipe deletedRecipe = repository.DeleteRecipe(RecipeId);

            if (deletedRecipe != null)
            {
                TempData["message"] = $"{deletedRecipe.Name} was deleted!";
            }

            return RedirectToAction("RecipeList", "Home");
        }
        

        
        
        
    }
}
