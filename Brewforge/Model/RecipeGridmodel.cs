using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    public class RecipeGridModel
    {
        public string gridName { get; set; }
        public List<recipe> recipes { get; set; }
        
        public recipe selectedRecipe { get; set; }
        
        public string selectedRecipeIndex { get; set; }
    }
}