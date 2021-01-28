using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecipeWebSite.Models
{
    public class Review
    {
        public int Taste { get; set; }
        public bool EasyToMake { get; set; }
        public bool WouldReccomend { get; set; }
        public string Thoughts { get; set; }

        // I made this class assuming that, later on, reviews might have to be saved and retrieved. Currently not doing anything.
    }
}
