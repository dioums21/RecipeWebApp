using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace RecipeWebSite.Models
{
    public static class SeedData
    {
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();

            context.Database.Migrate();

            if (!context.Recipes.Any())
            {
                context.Recipes.AddRange(

                    new Recipe
                    {
                        Name = "Toasted Caprese Sandwich",
                        Chef = "Landon Bryan",
                        Time = 25,
                        Ingredients =  "Garlic, 1 tbsp olive oil, 2 tbsp butter, Ciabatta loaf, 1 tbsp dried rosemary" ,
                        Description = "A yummy quick and easy sandwich to make to energize you before class!"
                    },
                    new Recipe
                    {
                        Name = "Falafel Bites",
                        Chef = "Emily Jaeger",
                        Time = 35,
                        Ingredients = "Chickpeas, 1 tbsp olive oil, 2 tbsp cillantro, 1 cup of bread crumbs, 1 tbsp dried rosemary",
                        Description = "A great bite sized boost of energy!"
                    },
                    new Recipe
                    {
                        Name = "Banana Bread",
                        Chef = "Emily Jaeger",
                        Time = 35,
                        Ingredients = "Bananas, 1 cup sugar, 2 cups chocolate chip, 1 cup of bread crumbs, 1 tbsp dried vanilla",
                        Description = "A quick and easy dessert!"
                    },
                    new Recipe
                    {
                        Name = "Caldo Verde",
                        Chef = "James Soares",
                        Time = 60,
                        Ingredients = "spinach, 1 tbsp olive oil, 2 chorizo, 1 potato, 1 tbsp dried rosemary",
                        Description = "A great and yummy soup!"
                    }
                    );

                context.SaveChanges();
                    
            }
        }
    }
}
