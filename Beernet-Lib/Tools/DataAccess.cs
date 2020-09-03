using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Beernet_Lib.Models;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RestSharp;

namespace Beernet_Lib.Tools
{
    public class DataAccess
    {
        public static IList<recipe> getRecipes(string apiLink, string apiAuthToken)
        {
                string jsonurl = apiLink;
                List<recipe> recipeList = new List<recipe>();
                var restClient = new RestClient(jsonurl);
                var request = new RestRequest(Method.GET);

                request.AddHeader("Authorization", "bearer " + apiAuthToken);

                var response = restClient.Execute(request);
                List<recipe> allRecipes = JsonConvert.DeserializeObject<List<recipe>>(response.Content);
                return allRecipes;
        }

        public static recipe getRecipeDetails(string apiLink, string apiAuthToken, string recipeID)
        {
            //string dataurl = "http://localhost:50422";
            string jsonurl = apiLink + recipeID;
            recipe recipes = new recipe();
            //var json = new WebClient().DownloadString(jsonurl);
            //recipes = JsonConvert.DeserializeObject<recipe>(json);

            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            recipes = JsonConvert.DeserializeObject<recipe>(response.Content);
            return recipes;
        }

        /*
         * Get all hops
         * */
        public static List<hopbase> getAllHops(string dataurl, string apiAuthToken)
        {
            string jsonurl = dataurl + "/beernet/hop";

            List<hopbase> hops = new List<hopbase>();

            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            hops = JsonConvert.DeserializeObject<List<hopbase>>(response.Content);
            return hops;
        }

        /*
         * Get all fermentables
         * */
        public static List<fermentable> getAllFermentables (string dataurl, string apiAuthToken)
        {
            string jsonurl = dataurl + "/beernet/fermentable";

            List<fermentable> fermentables = new List<fermentable>();

            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            fermentables = JsonConvert.DeserializeObject<List<fermentable>>(response.Content);
            return fermentables;
        }

        /*
        * Get all yeasts
        * */
        public static List<yeast> getAllYeasts(string dataurl, string apiAuthToken)
        {
            string jsonurl = dataurl + "/beernet/yeast";

            List<yeast> yeasts = new List<yeast>();

            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            yeasts = JsonConvert.DeserializeObject<List<yeast>>(response.Content);
            return yeasts;
        }

        /*
        * Get all adjuncts
        * */
        public static List<adjunct> getAllAdjuncts(string dataurl, string apiAuthToken)
        {
            string jsonurl = dataurl + "/beernet/adjunct";

            List<adjunct> adjuncts = new List<adjunct>();

            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            adjuncts = JsonConvert.DeserializeObject<List<adjunct>>(response.Content);
            return adjuncts;
        }

        /*
       * Get all styles
       * */
        public static List<style> getAllStyles(string dataurl, string apiAuthToken)
        {
            string jsonurl = dataurl + "/beernet/style";

            List<style> styles = new List<style>();

            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            styles = JsonConvert.DeserializeObject<List<style>>(response.Content);
            return styles;
        }

        public static userSettings getUserSettings(string apiAuthToken, string apiEndpoint)
        {
            string jsonurl = apiEndpoint + "/beernet/userSettings/";

            var client = new RestClient("" + jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);
            var response = client.Execute(request);
            userSettings returnable = JsonConvert.DeserializeObject<userSettings>(response.Content);
            return returnable;

            //BeerNet/userSettings
        }

        public static RecipeResponse postRecipe(recipe recipe, string dataurl, string apiAuthToken, bool save)
        {
            string jsonurl = "";

            if(recipe.equipmentProfile == null)
            {
                recipe.equipmentProfile = RecipeTools.getDefaultEquipmentProfile();
            }

            if(recipe.idString != null)
            {
                if (save)
                {
                    jsonurl = dataurl + "/beernet/recipe/" + recipe.idString;
                }
                else
                {
                    jsonurl = dataurl + "/beernet/recipe/" + recipe.idString + "/true";
                }
            }
            else
            {
                jsonurl = dataurl + "/beernet/recipe";
            }
            
             
            var client = new RestClient("" + dataurl);
            var request = new RestRequest(jsonurl, Method.POST);

            // Json to post.
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(recipe);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", "bearer " + apiAuthToken);
            var response = client.Execute(request);
            RecipeResponse returnable = JsonConvert.DeserializeObject<RecipeResponse>(response.Content);
            return returnable;
        }

        public static void deleteRecipe(recipe recipe, string dataurl, string apiAuthToken)
        {
            string jsonurl = "";

            if (recipe.idString != null)
            {
                    jsonurl = dataurl + "/beernet/recipe/" + recipe.idString;
            }
            else
            {
                return;
            }

            var client = new RestClient("" + dataurl);
            var request = new RestRequest(jsonurl, Method.DELETE);

            // Json to post.
            string jsonToSend = Newtonsoft.Json.JsonConvert.SerializeObject(recipe);
            request.AddParameter("application/json; charset=utf-8", jsonToSend, ParameterType.RequestBody);
            request.RequestFormat = DataFormat.Json;

            request.AddHeader("Authorization", "bearer " + apiAuthToken);
            var response = client.Execute(request);
            RecipeResponse returnable = JsonConvert.DeserializeObject<RecipeResponse>(response.Content);
        }

        public static List<BrewLog> getAllBrewLogs(string apiLink, string apiAuthToken)
        {
            string jsonurl = apiLink + "/beernet/BrewLog/";
            List<BrewLog> brewLog = new List<BrewLog>();

            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.GET);

            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            brewLog = JsonConvert.DeserializeObject<List<BrewLog>>(response.Content);
            return brewLog;
        }
    }
}
