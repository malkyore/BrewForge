using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Beernet_Lib.Tools;

namespace Craftly.Beer_Blazor.ComponentClasses
{
    public static class RecipeHelper
    {
        public static string currentRecipeId { get; set; }

        static Dictionary<string, string> values = new Dictionary<string, string>
            {
               { "Username", "" + "beer"},
               { "Password", "" + "Poopbutt1" }
            };

        static string apiLink = "http://rest.unacceptable.beer:5123";
        static string loginEndpoint = "/Beernet/Login/";

        public async static Task<List<recipe>> GetRecipes()
        {
            string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            List<recipe> allRecipes = DataAccess.getRecipes(apiLink + "/beernet/recipe/", token).ToList();
            return allRecipes;

        }

        public static recipe GetRecipeDetails(string recipeID)
        {
            string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            currentRecipeId = recipeID;

            recipe RecipeDetail = DataAccess.getRecipeDetails(apiLink + "/beernet/recipe/", token, recipeID);
            return RecipeDetail;

        }

        public static recipe initializeBlankRecipe()
        {
            recipe newRecipe = new recipe();

            newRecipe.name = "BeerRecipe1213145";
            newRecipe.description = "THISS S SJSJASJDJAJASJ BEERERRR";

            newRecipe.style = new style();

            newRecipe.style.name = "IPA";

            newRecipe.recipeStats = new RecipeStatistics
            {
                abv = 7F,
                fg = 1.04F,
                og = 1.064F,
                srm = 43,
                ibu = 67
            };

            newRecipe.adjuncts = new List<adjunctAddition>();
            newRecipe.fermentables = new List<fermentableAddition>();
            newRecipe.hops = new List<hopAddition>();
            newRecipe.yeasts = new List<yeastAddition>();
            hopAddition a = new hopAddition();
            a.hopID = "";
            a.type = "Boil";
            a.additionGuid = "";
            a.amount = 1;
            a.time = 60;
            hopbase b = new hopbase();
            b.aau = 1;
            b.type = "idk";
            b.substitutes = "";
            b.createdByUserId = "";
            b.idString = "";
            b.name = "Centennial";
            b.notes = "";
            b.origin = "";
            a.hop = b;
            newRecipe.hops.Add(a);
            

            fermentable f = new fermentable
            {
                color = 6,
                name = "2 Row",
                yield = 14.65F,
                maltster = "Breiss"
            };

            fermentableAddition fa = new fermentableAddition
            {
                use = "Mash",
                weight = 12.5F,
                fermentable = f
            };

            yeast y = new yeast
            {
                attenuation = 1.05F,
                lab = "Wyeast",
                name = "Wheat"
            };

            yeastAddition ya = new yeastAddition
            {
                yeast = y
        };

            adjunct ad = new adjunct
            {
                name = "Cocoa nibs"
            };

            adjunctAddition aa = new adjunctAddition
            {
                adjunct = ad,
                amount = 2,
                time = 60,
                timeUnit = "min",
                type = "boil",
                unit = "oz"
            };

            newRecipe.fermentables.Add(fa);
            newRecipe.yeasts.Add(ya);
            newRecipe.adjuncts.Add(aa);

            return newRecipe;
        }
    }
}
