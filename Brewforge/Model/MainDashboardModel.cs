using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    public class MainDashboardModel
    {
        public List<recipe> myRecipes { get; set; }
        
        public recipe selectedMyRecipe { get; set; }
        
        public string selectedMyRecipeIndex { get; set; }

        public List<recipe> publicRecipes { get; set; }

        public recipe selectedPublicRecipe { get; set; }

        public string selectedPublicRecipeIndex { get; set; }
    }
}