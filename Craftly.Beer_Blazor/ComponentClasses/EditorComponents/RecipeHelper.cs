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
        private static string LoginToken { get; set; }

        public static bool isLoggedIn { get; set; }

        //static Dictionary<string, string> values = new Dictionary<string, string>
        //    {
        //       { "Username", "" + "beer"},
        //       { "Password", "" + "Poopbutt1" }
        //    };

        //dev
        static string apiLink = "http://dev.unacceptable.beer:666";

        //prod
        //static string apiLink = "http://rest.unacceptable.beer:5123";
        static string loginEndpoint = "/Beernet/Login/";

        public static bool Login(string username, string password)
        {
            Dictionary<string, string> LoginInfo = new Dictionary<string, string>
            {
               { "Username", "" + username},
               { "Password", "" + password }
            };

            LoginToken = Auth.getAPIAuthToken(apiLink, loginEndpoint, LoginInfo).Replace("\"", "");
            if(LoginToken == "Unauthorized" || LoginToken == "Unknown Error")
            {
                isLoggedIn = false;
                return false;
            }
            else
            {
                isLoggedIn = true;
                return true;
            }
            
        }

        public static void Logout()
        {
            isLoggedIn = false;
            LoginToken = null;
        }

        public async static Task<List<recipe>> GetRecipes()
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            List<recipe> allRecipes = DataAccess.getRecipes(apiLink + "/beernet/recipe/", LoginToken).ToList();
            return allRecipes;

        }

        public static List<style> GetAllStyles()
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            return DataAccess.getAllStyles(apiLink, LoginToken);
        }

        public static recipe GetRecipeDetails(string recipeID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            currentRecipeId = recipeID;

            recipe RecipeDetail = DataAccess.getRecipeDetails(apiLink + "/beernet/recipe/", LoginToken, recipeID);
            return RecipeDetail;

        }

        public static List<hopbase> GetAllHops()
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            //currentRecipeId = recipeID;

            List<hopbase> listOfHops = new List<hopbase>();

            listOfHops = DataAccess.getAllHops(apiLink, LoginToken);

            return listOfHops;

        }

        public static List<fermentable> GetAllFermentables()
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            List<fermentable> listOfFermentables = new List<fermentable>();

            listOfFermentables = DataAccess.getAllFermentables(apiLink, LoginToken);

            return listOfFermentables;

        }

        public static List<yeast> GetAllYeasts()
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            List<yeast> listOfYeasts = new List<yeast>();

            listOfYeasts = DataAccess.getAllYeasts(apiLink, LoginToken);

            return listOfYeasts;

        }

        public static List<adjunct> GetAllAdjuncts()
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            List<adjunct> listOfadjuncts = new List<adjunct>();

            listOfadjuncts = DataAccess.getAllAdjuncts(apiLink, LoginToken);

            return listOfadjuncts;

        }

        public static RecipeResponse SaveRecipe(recipe recipe, bool save)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            RecipeResponse stats = DataAccess.postRecipe(recipe, apiLink, LoginToken, save);
            return stats;
        }

        public static void DeleteRecipe(recipe recipe)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            DataAccess.deleteRecipe(recipe, apiLink, LoginToken);
        }

        public static recipe initializeBlankRecipe()
        {
            recipe newRecipe = new recipe();

            currentRecipeId = "-1";

            newRecipe.name = "";
            newRecipe.description = "";

            newRecipe.style = new style();

            newRecipe.recipeStats = new RecipeStatistics
            {
                abv = 0,
                fg = 0,
                og = 0,
                srm = 0,
                ibu = 0
            };

            RecipeParameters rp = new RecipeParameters
            {
                fermentableCalcType = "basic",
                ibuBoilTimeCurveFit = -0.04F,
                ibuCalcType = "basic",
                intoFermenterVolume = 0
            };

            newRecipe.recipeParameters = rp;

            newRecipe.adjuncts = new List<adjunctAddition>();
            newRecipe.fermentables = new List<fermentableAddition>();
            newRecipe.hops = new List<hopAddition>();
            newRecipe.yeasts = new List<yeastAddition>();
            //hopAddition a = new hopAddition();
            //a.hopID = "";
            //a.type = "";
            //a.additionGuid = "";
            //a.amount = 0;
            //a.time = 0;
            //hopbase b = new hopbase();
            //b.aau = 1;
            //b.type = "idk";
            //b.substitutes = "";
            //b.createdByUserId = "";
            //b.idString = "";
            //b.name = "Centennial";
            //b.notes = "";
            //b.origin = "";
            //a.hop = b;
            //newRecipe.hops.Add(a);


            //    fermentable f = new fermentable
            //    {
            //        color = 6,
            //        name = "2 Row",
            //        yield = 14.65F,
            //        maltster = "Breiss"
            //    };

            //    fermentableAddition fa = new fermentableAddition
            //    {
            //        use = "Mash",
            //        weight = 12.5F,
            //        fermentable = f
            //    };

            //    yeast y = new yeast
            //    {
            //        attenuation = 1.05F,
            //        lab = "Wyeast",
            //        name = "Wheat"
            //    };

            //    yeastAddition ya = new yeastAddition
            //    {
            //        yeast = y
            //};

            //    adjunct ad = new adjunct
            //    {
            //        name = "Cocoa nibs"
            //    };

            //    adjunctAddition aa = new adjunctAddition
            //    {
            //        adjunct = ad,
            //        amount = 2,
            //        time = 60,
            //        timeUnit = "min",
            //        type = "boil",
            //        unit = "oz"
            //    };

            //    newRecipe.fermentables.Add(fa);
            //    newRecipe.yeasts.Add(ya);
            //    newRecipe.adjuncts.Add(aa);

            return newRecipe;
        }
    }
}
