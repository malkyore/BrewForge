
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;



namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class RecipeSelector : ComponentBase
    {
        public static string operatorvalue = "";
        [Parameter]
        public recipe Model { get; set; }//= RecipeHelper.initializeBlankRecipe();
        [Parameter]
        public List<recipe> recipes { get; set; }
        public static string selectedRecipeIndex { get; set; }

        public async void loadRecipe(string idString)
        {
            Model = RecipeHelper.GetRecipeDetails(idString);
        }

        private void OenRecipe()
        {
            
            
        }
    }
}
