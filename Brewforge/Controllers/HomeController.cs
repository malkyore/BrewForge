using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Hosting;
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
        public static int currentSelectedYeast { get; set; }
        public static int currentSelectedAdjunct { get; set; }
        public static string currentSelectedRecipe { get; set; }
        public static string currentSelectedStyle { get; set; }
        public static List<hopbase> hopOptions { get; set; }
        public static List<fermentable> fermentableOptions { get; set; }
        public static List<yeast> yeastOptions { get; set; }
        public static List<adjunct> adjunctOptions { get; set; }
        public static List<style> styleOptions { get; set; }

        public static MainDashboardModel dashboardModel = new MainDashboardModel();
        public static List<BrewLog> activeBrewLogs = new List<BrewLog>();


        [HttpGet()]
        public virtual IActionResult RecipeViewer(string selectedRecipe = "-1")
        {
            RecipeSelectorViewModel model = new RecipeSelectorViewModel();
            IList<recipe> allRecipes = new List<recipe>();

            allRecipes = DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken);

            model.selectedRecipeIndex = currentSelectedRecipe;

            if (selectedRecipe != "-1")
            {
                currentSelectedRecipe = selectedRecipe;
                model.selectedRecipe = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, currentSelectedRecipe);
                model.selectedRecipeIndex = selectedRecipe;
            }
            else
            {
                model.selectedRecipe = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, allRecipes[0].idString);
                currentSelectedRecipe = allRecipes[0].idString;
            }
            
            model.allRecipes = allRecipes.ToList();
            String path = Request.Path;

            var controllerName = GetType().Name.Substring(0, GetType().Name.IndexOf("controller", StringComparison.CurrentCultureIgnoreCase));

            if (path == "/")
                path += controllerName;

            if (path.IndexOf(@"/index", StringComparison.OrdinalIgnoreCase) == -1)
                return Redirect((path + "/Index").Replace("//", "/"));

            return View(model);
        }

        public virtual IActionResult Index(string gridName, string selectedRecipe)
        {
            recipe selectedRecipeDetails = new recipe();
            List<recipe> myRecipes = myRecipes = (List<recipe>)DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken).Where(x => x.createdByUserID == AppSettings.userSettings.userID).ToList<recipe>();
            List<recipe> publicRecipes = (List<recipe>)DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken).Where(x => x.isPublic == true).ToList<recipe>();
            activeBrewLogs = DataAccess.getAllBrewLogs(AppSettings.apiLink, AppSettings.apiAuthToken);


            if (!String.IsNullOrEmpty(selectedRecipe))
            {
                selectedRecipeDetails = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, selectedRecipe);
                switch (gridName)
                {
                    case "myRecipes":
                        dashboardModel.myRecipes = myRecipes;
                        dashboardModel.selectedMyRecipe = selectedRecipeDetails;
                        dashboardModel.selectedMyRecipeIndex = selectedRecipe;
                        break;
                    case "publicRecipes":
                        selectedRecipeDetails = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, selectedRecipe);
                        dashboardModel.publicRecipes = publicRecipes;
                        dashboardModel.selectedPublicRecipe = selectedRecipeDetails;
                        dashboardModel.selectedPublicRecipeIndex = selectedRecipe;
                        break;
                }
               
               
            }
            else
            {
                dashboardModel.myRecipes = myRecipes;
                dashboardModel.publicRecipes = publicRecipes;
                if(myRecipes.Count > 0)
                {
                    dashboardModel.selectedMyRecipe = myRecipes[0];
                    dashboardModel.selectedPublicRecipe = myRecipes[0];
                    dashboardModel.selectedMyRecipeIndex = myRecipes[0].idString;
                    dashboardModel.selectedPublicRecipeIndex = myRecipes[0].idString;
                } 
                else
                {
                    dashboardModel.selectedMyRecipe = RecipeTools.makeEmptyRecipe(AppSettings.userSettings.userID);
                    dashboardModel.selectedPublicRecipe = RecipeTools.makeEmptyRecipe(AppSettings.userSettings.userID);
                    dashboardModel.selectedMyRecipeIndex = "";
                    dashboardModel.selectedPublicRecipeIndex = "";
                }
                
            }
            dashboardModel.activeBrewLogs = activeBrewLogs;

            return View(dashboardModel);
        }

    }
}
