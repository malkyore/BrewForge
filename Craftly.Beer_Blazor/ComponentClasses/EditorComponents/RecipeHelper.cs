using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Beernet_Lib.Tools;

namespace Craftly.Beer_Blazor.ComponentClasses
{
    public class UserSessionItem
    {
        public string sessionID { get; set; }
        public string authToken { get; set; }
        public DateTime expiryTimestamp { get; set; }
    }

    public static class RecipeHelper
    {
        static List<UserSessionItem> UserSessions { get; set; } = new List<UserSessionItem>();
        public static string currentRecipeId { get; set; }
        //private static string LoginToken { get; set; }

        //public static bool isLoggedIn { get; set; }

        private static int LoginExpiryDays { get; set; } = 10;
        //dev
        static string apiLink = "http://dev.unacceptable.beer:666";

        ////devdb locally
        //static string apiLink = "http://host.docker.internal:50422";

        //prod
        //static string apiLink = "http://rest.unacceptable.beer:5123";
        static string loginEndpoint = "/Beernet/Login/";
        static string createAccountEndpoint = "/Beernet/Register/";


        public static string retrieveToken(string sessionID)
        {
            var currentSesh = UserSessions.Where(x => x.sessionID == sessionID).FirstOrDefault();

            if (currentSesh != null && !(currentSesh.expiryTimestamp < DateTime.Now))
            {
                return currentSesh.authToken;
            }
            else
            {
                UserSessions.Remove(currentSesh);
                return "expired";
            }
        }
        public static bool isLoggedIn(string sessionID)
        {
            var currentSesh = UserSessions.Where(x => x.sessionID == sessionID);

            if (currentSesh.Any())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string storeLoginSession(string Token)
        {
            string sessionGuid = Guid.NewGuid().ToString();
            UserSessionItem sesh = new UserSessionItem();
            sesh.sessionID = sessionGuid;
            sesh.authToken = Token;
            sesh.expiryTimestamp = DateTime.Now.AddDays(LoginExpiryDays);
            UserSessions.Add(sesh);
            return sessionGuid;
        }

        public static string Login(string username, string password)
        {
            Dictionary<string, string> LoginInfo = new Dictionary<string, string>
            {
               { "Username", "" + username},
               { "Password", "" + password }
            };

            string LoginToken = Auth.getAPIAuthToken(apiLink, loginEndpoint, LoginInfo).Replace("\"", "");
            if(LoginToken == "Unauthorized" || LoginToken == "Unknown Error")
            {
                //isLoggedIn = false;
                return "false";
            }
            else
            {
                //isLoggedIn = true;
                return storeLoginSession(LoginToken);
            }
            
        }

        public static string CreateAccount(string username, string email, string password)
        {
            Dictionary<string, string> AccountInfo = new Dictionary<string, string>
            {
                {"Username", "" + username },
                {"Email", "" + email },
                {"Password", "" + password }
            };

            string creationResponse = Auth.createNewUserAccount(apiLink, createAccountEndpoint, AccountInfo);

            return creationResponse;
        }

        public static void Logout(string sessionID)
        {
            var sesh = UserSessions.Where(X => X.sessionID == sessionID).FirstOrDefault();
            UserSessions.Remove(sesh);
            //isLoggedIn = false;
            //LoginToken = null;
        }

        public async static Task<List<recipe>> GetRecipes(string sessionID)
        {
            string LoginToken = retrieveToken(sessionID);//Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            List<recipe> allRecipes = DataAccess.getRecipes(apiLink + "/beernet/recipe/", LoginToken).ToList();
            return allRecipes;

        }

        public static List<style> GetAllStyles(string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            string LoginToken = retrieveToken(sessionID);
            return DataAccess.getAllStyles(apiLink, LoginToken);
        }

        public static recipe GetRecipeDetails(string recipeID, string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            string LoginToken = retrieveToken(sessionID);
            currentRecipeId = recipeID;

            recipe RecipeDetail = DataAccess.getRecipeDetails(apiLink + "/beernet/recipe/", LoginToken, recipeID);
            return RecipeDetail;

        }

        public static List<hopbase> GetAllHops(string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");

            //currentRecipeId = recipeID;
            string LoginToken = retrieveToken(sessionID);

            List<hopbase> listOfHops = new List<hopbase>();

            listOfHops = DataAccess.getAllHops(apiLink, LoginToken);

            return listOfHops;

        }

        public static List<fermentable> GetAllFermentables(string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            string LoginToken = retrieveToken(sessionID);

            List<fermentable> listOfFermentables = new List<fermentable>();

            listOfFermentables = DataAccess.getAllFermentables(apiLink, LoginToken);

            return listOfFermentables;

        }

        public static List<yeast> GetAllYeasts(string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            string LoginToken = retrieveToken(sessionID);

            List<yeast> listOfYeasts = new List<yeast>();

            listOfYeasts = DataAccess.getAllYeasts(apiLink, LoginToken);

            return listOfYeasts;

        }

        public static List<adjunct> GetAllAdjuncts(string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            string LoginToken = retrieveToken(sessionID);

            List<adjunct> listOfadjuncts = new List<adjunct>();

            listOfadjuncts = DataAccess.getAllAdjuncts(apiLink, LoginToken);

            return listOfadjuncts;

        }

        public static RecipeResponse SaveRecipe(recipe recipe, bool save, string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            string LoginToken = retrieveToken(sessionID);
            RecipeResponse stats = DataAccess.postRecipe(recipe, apiLink, LoginToken, save);
            return stats;
        }

        public static void DeleteRecipe(recipe recipe, string sessionID)
        {
            //string token = Auth.getAPIAuthToken(apiLink, loginEndpoint, values).Replace("\"", "");
            string LoginToken = retrieveToken(sessionID);
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

            newRecipe.equipmentProfile = RecipeTools.getDefaultEquipmentProfile();

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
