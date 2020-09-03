
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Microsoft.AspNetCore.ProtectedBrowserStorage;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class RecipeSelector : ComponentBase
    {
        [Inject]
        ProtectedSessionStorage ProtectedSessionStore { get; set; }
        public static string operatorvalue = "";
        [Parameter]
        public recipe Model { get; set; }
        [Parameter]
        public List<recipe> recipes { get; set; }
        public static string selectedRecipeIndex { get; set; }

        public async void loadRecipe(string idString)
        {
            Model = RecipeHelper.GetRecipeDetails(idString, getSessionID());
        }
        protected override void OnInitialized()
        {
            
            if(recipes.Count > 0)
            {
                selectedRecipeIndex = recipes[0].idString;
                loadRecipe(recipes[0].idString);
            }
        }
        public void NewRecipe()
        {
            selectedRecipeIndex = "-1";
            RecipeHelper.currentRecipeId = "-1";
        }

        public int findRecipeIndex()
        {
            int i = 0;
            int indexOfHop = 0;
            foreach (recipe r in recipes)
            {
                if (Model.idString == r.idString)
                {
                    indexOfHop = i;
                    break;
                }
                i++;
            }
            return indexOfHop;
        }

        public async void ClickDeleteRecipe(object args, string text)
        {
            int current = findRecipeIndex();
            RecipeHelper.DeleteRecipe(Model, getSessionID());
            recipes = await RecipeHelper.GetRecipes(getSessionID());
            loadRecipe(recipes[current].idString);
        }
        public async void setSessionID(string sessionState)
        {
            await ProtectedSessionStore.SetAsync("session", sessionState);
        }

        public string getSessionID()
        {
            return ProtectedSessionStore.GetAsync<string>("session").Result;
        }
    }
}
