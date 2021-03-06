﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RecipeWebSite.Models;
using RecipeWebSite.Models.ViewModel;

namespace RecipeWebSite.Models.ViewModel
{
    public class PaginatedList<Recipe> : List<Recipe>
    {
        public int PageIndex { get; set; }
        public int TotalPages { get; set; }

        public PaginatedList(List<Recipe> recipes, int count,int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);

            this.AddRange(recipes);
        }

        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 1);
            }
        }

        public bool HasNextPage
        {
            get
            {
                return (PageIndex < TotalPages );
            }
        }

        public static async Task<PaginatedList<Recipe>> CreateAsync(IQueryable<Recipe> source, int pageIndex, int pageSize)
        {
            var count =  await source.CountAsync();
            var items = await source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToListAsync();

            return new PaginatedList<Recipe>(items, count, pageIndex, pageSize);
        }
    }


}
