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
            //string dataurl = "http://rest.unacceptable.beer:5123";
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
         * Get the hops for a recipe.
         * 
         * These suck and they waste a bunch of time getting the whole recipe like 4 times.
         * 
         * */
        public static IList<hopAddition> getRecipeHops(string idString)
        {
            string dataurl = "http://rest.unacceptable.beer:5123";
            string jsonurl = dataurl + "/beernet/recipe/" + idString;
            recipe recipes = new recipe();
            var json = new WebClient().DownloadString(jsonurl);
            recipes = JsonConvert.DeserializeObject<recipe>(json);
            return recipes.hops;
        }

        /*
         * Get Fermentables for a recipe
         * */
        public static IList<fermentableAddition> getRecipeFermentables(string idString)
        {
            string dataurl = "http://rest.unacceptable.beer:5123";
            string jsonurl = dataurl + "/beernet/recipe/" + idString;
            recipe recipes = new recipe();
            var json = new WebClient().DownloadString(jsonurl);
            recipes = JsonConvert.DeserializeObject<recipe>(json);
            return recipes.fermentables;
        }

        /*
         * Get yeasts for a recipe.
         * */
        public static IList<yeast> getRecipeYeasts(string idString)
        {
            string dataurl = "http://rest.unacceptable.beer:5123";
            string jsonurl = dataurl + "/beernet/recipe/" + idString;
            recipe recipes = new recipe();
            var json = new WebClient().DownloadString(jsonurl);
            recipes = JsonConvert.DeserializeObject<recipe>(json);
            return recipes.yeasts.ToList<yeast>();
        }

        /*
         * Get Adjuncts for a recipe
         * */
        public static IList<adjunctAddition> getRecipeAdjuncts(string idString)
        {
            string dataurl = "http://rest.unacceptable.beer:5123";
            string jsonurl = dataurl + "/beernet/recipe/" + idString;
            recipe recipes = new recipe();
            var json = new WebClient().DownloadString(jsonurl);
            recipes = JsonConvert.DeserializeObject<recipe>(json);
            return recipes.adjuncts;
        }

        public static RecipeResponse postRecipe(recipe recipe, string apiAuthToken)
        {
            string dataurl = "http://rest.unacceptable.beer:5123";
            string jsonurl = dataurl + "/beernet/recipe/" + recipe.id;


            var restClient = new RestClient(jsonurl);
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-type", "application/json");
            request.AddJsonBody(recipe);
            request.AddHeader("Authorization", "bearer " + apiAuthToken);

            var response = restClient.Execute(request);
            //request.RequestFormat = DataFormat.Json;
            //request.AddHeader("Content-type", "application/json");
            //request.AddJsonBody(recipe);
            //request.AddHeader("Authorization", "bearer " + apiAuthToken);
            //IRestResponse response = client.Execute(request);
            RecipeResponse returnable = JsonConvert.DeserializeObject<RecipeResponse>(response.Content);
            return returnable;
        }

    }
}
