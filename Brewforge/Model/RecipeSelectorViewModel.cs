using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    public class RecipeSelectorViewModel
    {
        public List<recipe> allRecipes { get; set; }

        public recipe selectedRecipe { get; set; }

        public string selectedRecipeIndex { get; set; }

    }
}