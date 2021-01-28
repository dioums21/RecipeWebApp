using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecipeWebSite.Models;
using RecipeWebSite.Models.ViewModel;

namespace RecipeWebSite.Controllers
{
    public class HomeController : Controller
    {
        private IRecipeRepository repository;
        

        public HomeController(IRecipeRepository repo)
        {
            repository = repo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RecipeList(string currentFilter, string searchString, int? pageNumber)
        {
            

            if (searchString != null)
            {
                pageNumber = 1;
            }
            else
            {
                searchString = currentFilter;
            }

            ViewData["currentFilter"] = searchString;

            var recipes = repository.Recipes;

            if (!String.IsNullOrEmpty(searchString))
            {
                recipes = recipes.Where(
                       r => r.Name.ToLower().Contains(searchString.ToLower())
                    || r.Ingredients.ToLower().Contains(searchString.ToLower())
                    || r.Description.ToLower().Contains(searchString.ToLower())
                    || r.Chef.ToLower().Contains(searchString.ToLower()));
            }

            int pageSize = 3;

            return View(await PaginatedList<Recipe>.CreateAsync(recipes, pageNumber ?? 1, pageSize));


        }

  

        public ViewResult ReviewRecipe()
        {
            return View();
        }

    }
}
