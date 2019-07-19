using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
//using DataGridDemo.Model;
using Brewforge.Models;
using System.Text;
using System.Reflection;
using System.Linq.Dynamic.Core;
using Newtonsoft.Json;
using System.Net;
using RestSharp;
using Beernet_Lib.Models;
using Beernet_Lib.Tools;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Http;

namespace Brewforge.Controllers
{
    public class HomeController : BaseController
    {
        private IHostingEnvironment hostingEnvironment;

        public HomeController(IOptions<AppSettings> settings, IHostingEnvironment env) : base(settings)
        {

        }
        public static recipe recipeDetails { get; set; }

        public static int currentSelectedHop { get; set; }
        public static int currentSelectedFermentable { get; set; }

        //Save all the recipes stats (for now until we get more legit it just uses ViewBag....)
        private void populateRecipeInfo()
        {
            recipe recipes = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, ViewBag.recipeID);
            ViewBag.recipeName = recipes.name;
            ViewBag.style = recipes.style;
            ViewBag.description = recipes.description;
            ViewBag.recipeStats = recipes.recipeStats;
            HttpContext.Items["recipeDetails"] = recipes;
            TempData.Remove("recipeDetails");
            TempData.Add("recipeDetails", JsonConvert.SerializeObject(recipes));
        }

        /*
         * loads all the data for all the recipes.
         * */
        [HttpGet]
        public virtual ActionResult LoadRecipes(String sort, String order, String search, Int32 limit, Int32 offset, String ExtraParam)
        {
            // Get entity fieldnames
            List<String> columnNames = typeof(recipe).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToList();

            // Create a seperate list for searchable field names   
            List<String> searchFields = new List<String>(columnNames);

            // Perform filtering
            IQueryable items = SearchItems(DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken).AsQueryable(), search, searchFields);

            // Sort the filtered items and apply paging
            return Content(ItemsToJson(items, columnNames, sort, order, limit, offset), "application/json");
        }


        /*
         * load the list of hops for the hop grid
         * */
        [HttpGet]
        public virtual ActionResult LoadHop(String sort, String order, String search, Int32 limit, Int32 offset, String ExtraParam)
        {
            recipe recipeDetails;
            recipeDetails = JsonConvert.DeserializeObject<recipe>(TempData.Peek("recipeDetails").ToString());

            // Get entity fieldnames
            List<String> columnNames = typeof(hopAddition).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToList();

            // Create a seperate list for searchable field names   
            List<String> searchFields = new List<String>(columnNames);

            // Sort the filtered items and apply paging
            return Content(ItemsToJson(recipeDetails.hops.AsQueryable(), columnNames, sort, order, limit, offset), "application/json");
        }

        /*
         * load the list of fermentables for the fermentable grid
         * */
        [HttpGet]
        public virtual ActionResult LoadFermentable(String sort, String order, String search, Int32 limit, Int32 offset, String ExtraParam)
        {
            recipe recipeDetails;
            recipeDetails = JsonConvert.DeserializeObject<recipe>(TempData.Peek("recipeDetails").ToString());

            // Get entity fieldnames
            List<String> columnNames = typeof(fermentableAddition).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToList();

            // Create a seperate list for searchable field names   
            List<String> searchFields = new List<String>(columnNames);

            // Sort the filtered items and apply paging
            return Content(ItemsToJson(recipeDetails.fermentables.AsQueryable(), columnNames, sort, order, limit, offset), "application/json");
        }

        /*
         * Load the list of yeasts for the yeast grid
         * */
        [HttpGet]
        public virtual ActionResult LoadYeast(String sort, String order, String search, Int32 limit, Int32 offset, String ExtraParam)
        {
            recipe recipeDetails;
            recipeDetails = JsonConvert.DeserializeObject<recipe>(TempData.Peek("recipeDetails").ToString());

            // Get entity fieldnames
            List<String> columnNames = typeof(yeast).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToList();

            // Create a seperate list for searchable field names   
            List<String> searchFields = new List<String>(columnNames);


            // Sort the filtered items and apply paging
            return Content(ItemsToJson(recipeDetails.yeasts.AsQueryable(), columnNames, sort, order, limit, offset), "application/json");
        }

        /*
         * Load the list of Adjuncts for the Adjunct grid.
         * */
        [HttpGet]
        public virtual ActionResult LoadAdjunct(String sort, String order, String search, Int32 limit, Int32 offset, String ExtraParam)
        {
            recipe recipeDetails;
            recipeDetails = JsonConvert.DeserializeObject<recipe>(TempData.Peek("recipeDetails").ToString());

            // Get entity fieldnames
            List<String> columnNames = typeof(adjunctAddition).GetProperties(BindingFlags.Public | BindingFlags.Instance).Select(p => p.Name).ToList();

            // Create a seperate list for searchable field names   
            List<String> searchFields = new List<String>(columnNames);

            // Sort the filtered items and apply paging
            return Content(ItemsToJson(recipeDetails.adjuncts.AsQueryable(), columnNames, sort, order, limit, offset), "application/json");
        }

        /*
         * Opens the selected recipe 
         * */
        public virtual ActionResult openRecipe(String idString)
        {
            if (idString != "LoadHop" && idString != "LoadFermentable")
            {
                ViewBag.recipeID = idString;
                HttpContext.Items.Add("recipeID", idString);
                HttpContext.Session.Set("recipeID", Encoding.ASCII.GetBytes(idString));
            }
             recipeDetails = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, ViewBag.recipeID);
            EditorViewModel e = new EditorViewModel();
            e.currentRecipe = recipeDetails;
            e.selectedHopAddition = recipeDetails.hops[0];
            e.selectedFermentableAddition = recipeDetails.fermentables[0];
            return View("Views/Home/RecipeView.cshtml", e);
        }


        public virtual IActionResult testThing (EditorViewModel returnModel, int selectedHop = -1, int selectedFermentable = -1)
        {
            bool save = false;
            if(selectedHop == -1)
            {
                if(currentSelectedHop != null)
                {
                    selectedHop = currentSelectedHop;
                }
                else
                {
                    selectedHop = 0;
                }
            }
            else
            {
                currentSelectedHop = selectedHop;
            }

            if(selectedFermentable == -1)
            {
                if(currentSelectedFermentable != null)
                {
                    selectedFermentable = currentSelectedFermentable;
                }
                else
                {
                    selectedHop = 0;
                }
            }
            else
            {
                currentSelectedFermentable = selectedFermentable;
            }

            if(returnModel.selectedFermentableAddition != null)
            {
                recipeDetails.fermentables[currentSelectedFermentable] = returnModel.selectedFermentableAddition;
                save = true;
            }

            if(returnModel.selectedHopAddition != null)
            {
                recipeDetails.hops[currentSelectedHop] = returnModel.selectedHopAddition;
                save = true;
            }

            if (save)
            {
                RecipeResponse RecipeStats = DataAccess.postRecipe(recipeDetails, AppSettings.apiAuthToken);

                recipeDetails.recipeStats = RecipeStats.recipeStats;
            }

            var a = HttpContext.Session.Get("data");
            EditorViewModel e = new EditorViewModel();
            e.currentRecipe = recipeDetails;
            e.selectedHopAddition = recipeDetails.hops[selectedHop];
            e.selectedFermentableAddition = recipeDetails.fermentables[selectedFermentable];
            return View("Views/Home/RecipeView.cshtml", e);
        }
    }
}
