using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebSite.Models
{
    public class EFRecipeRepository : IRecipeRepository
    {
        private ApplicationDbContext context;

        public EFRecipeRepository(ApplicationDbContext ctx)
        {
            context = ctx;
        }

        public IQueryable<Recipe> Recipes => context.Recipes;

        public void SaveRecipe(Recipe recipe)
        {
            if (recipe.RecipeId == 0)
            {
                context.Recipes.Add(recipe);
                
            }
            else
            {
                Recipe entry = context.Recipes.FirstOrDefault(r => r.RecipeId == recipe.RecipeId);

                if (entry !=null)
                {
                    entry.Name = recipe.Name;
                    entry.Chef = recipe.Chef;
                    entry.Description = recipe.Description;
                    entry.Time = recipe.Time;
                    entry.Ingredients = recipe.Ingredients;
                }
            }
            context.SaveChanges();
        }

        public Recipe DeleteRecipe(int id)
        {
            Recipe entry = context.Recipes.FirstOrDefault(r => r.RecipeId == id);

            if (entry != null)
            {
                context.Recipes.Remove(entry);
                context.SaveChanges();

            }

            return entry;
        }
    }
}
