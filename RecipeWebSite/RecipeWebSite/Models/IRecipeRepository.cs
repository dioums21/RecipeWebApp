using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebSite.Models
{
    public interface IRecipeRepository
    {
        IQueryable<Recipe> Recipes { get; }

        void SaveRecipe(Recipe recipe);

        Recipe DeleteRecipe(int id);


    }
}
