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
        [HttpGet()]
        public virtual IActionResult Index(string selectedRecipe = "-1")
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
        /*
         * Opens the selected recipe 
         * */
        public virtual ActionResult openRecipe(String openRecipe)
        {
            EditorViewModel e = new EditorViewModel();
            if (openRecipe == "NEW")
            {
                recipeDetails = makeEmptyRecipe();
                hopOptions = DataAccess.getAllHops(AppSettings.apiAuthToken);
                fermentableOptions = DataAccess.getAllFermentables(AppSettings.apiAuthToken);
                yeastOptions = DataAccess.getAllYeasts(AppSettings.apiAuthToken);
                adjunctOptions = DataAccess.getAllAdjuncts(AppSettings.apiAuthToken);
                styleOptions = DataAccess.getAllStyles(AppSettings.apiAuthToken);

                e.styleOptions = styleOptions;
                e.currentRecipe = recipeDetails;
                e.selectedHopAddition = makeEmptyHopAddition();

                e.selectedFermentableAddition = makeEmptyFermentablAddition();
                e.selectedYeastAddition = makeEmptyYeastAddition();

                e.selectedAdjunctAddition = makeEmptyAdjunctAddition();
                e.selectedHopAdditionIndex = currentSelectedHop;
                e.selectedFermentableAdditionIndex = currentSelectedFermentable;
                e.hopOptions = hopOptions;
                e.fermentableOptions = fermentableOptions;
                e.yeastOptions = yeastOptions;
                e.adjunctOptions = adjunctOptions;

                e.style = styleOptions[0];
            }
            else
            {

                currentSelectedFermentable = 0;
                currentSelectedHop = 0;
                currentSelectedYeast = 0;
                currentSelectedAdjunct = 0;
                
                
                recipeDetails = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, openRecipe);
                e.currentRecipe = recipeDetails;
                if (recipeDetails.hops.Count > 0)
                {
                    e.selectedHopAddition = recipeDetails.hops[0];
                }
                else
                {
                    e.selectedHopAddition = makeEmptyHopAddition();
                }

                if (recipeDetails.fermentables.Count > 0)
                {
                    e.selectedFermentableAddition = recipeDetails.fermentables[0];
                }
                else
                {
                    e.selectedFermentableAddition = makeEmptyFermentablAddition();
                }

                if (recipeDetails.yeasts.Count > 0)
                {
                    e.selectedYeastAddition = recipeDetails.yeasts[0];
                }
                else
                {
                    e.selectedYeastAddition = makeEmptyYeastAddition();
                }

                if (recipeDetails.adjuncts.Count > 0)
                {
                    e.selectedAdjunctAddition = recipeDetails.adjuncts[0];
                }
                else
                {
                    e.selectedAdjunctAddition = makeEmptyAdjunctAddition();
                }

                hopOptions = DataAccess.getAllHops(AppSettings.apiAuthToken);
                fermentableOptions = DataAccess.getAllFermentables(AppSettings.apiAuthToken);
                yeastOptions = DataAccess.getAllYeasts(AppSettings.apiAuthToken);
                adjunctOptions = DataAccess.getAllAdjuncts(AppSettings.apiAuthToken);
                styleOptions = DataAccess.getAllStyles(AppSettings.apiAuthToken);

                currentSelectedStyle = styleOptions[0].idString;
                e.styleOptions = styleOptions;
                e.selectedHopAdditionIndex = currentSelectedHop;
                e.selectedFermentableAdditionIndex = currentSelectedFermentable;
                e.hopOptions = hopOptions;
                e.fermentableOptions = fermentableOptions;
                e.yeastOptions = yeastOptions;
                e.adjunctOptions = adjunctOptions;
                if(recipeDetails.style == null)
                {
                    e.style = styleOptions[0];
                }
                else
                {
                    e.style = recipeDetails.style;
                }
            }
            return View("Views/Home/RecipeView.cshtml", e);
        }

        public virtual IActionResult Dashboard(string gridName, string selectedRecipe)
        {
            recipe selectedRecipeDetails = new recipe();
            List<recipe> allRecipes = new List<recipe>();
            
            

            if (!String.IsNullOrEmpty(selectedRecipe))
            {
                selectedRecipeDetails = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, selectedRecipe);
                switch (gridName)
                {
                    case "myRecipes":
                        allRecipes = (List<recipe>)DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken).Where(x => x.fermentables.Count > 3).ToList<recipe>();
                        dashboardModel.myRecipes = allRecipes;
                        dashboardModel.selectedMyRecipe = selectedRecipeDetails;
                        dashboardModel.selectedMyRecipeIndex = selectedRecipe;
                        break;
                    case "publicRecipes":
                        allRecipes = (List<recipe>)DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken);
                        selectedRecipeDetails = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, selectedRecipe);
                        dashboardModel.publicRecipes = allRecipes;
                        dashboardModel.selectedPublicRecipe = selectedRecipeDetails;
                        dashboardModel.selectedPublicRecipeIndex = selectedRecipe;
                        break;
                }
               
               
            }
            else
            {
                allRecipes = (List<recipe>)DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken);
                List<recipe> allMyRecipes = (List<recipe>)DataAccess.getRecipes(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken).Where(x => x.fermentables.Count > 3).ToList<recipe>();
                dashboardModel.myRecipes = allMyRecipes;
                dashboardModel.publicRecipes = allRecipes;
                if(allMyRecipes.Count > 0)
                {
                    dashboardModel.selectedMyRecipe = allMyRecipes[0];
                    dashboardModel.selectedPublicRecipe = allRecipes[0];
                    dashboardModel.selectedMyRecipeIndex = allMyRecipes[0].idString;
                    dashboardModel.selectedPublicRecipeIndex = allRecipes[0].idString;
                } 
                else
                {
                    dashboardModel.selectedMyRecipe = makeEmptyRecipe();
                    dashboardModel.selectedPublicRecipe = makeEmptyRecipe();
                    dashboardModel.selectedMyRecipeIndex = "";
                    dashboardModel.selectedPublicRecipeIndex = "";
                }
                
            }

            return View(dashboardModel);
        }

        public virtual IActionResult testThing (
            EditorViewModel returnModel, 
            int selectedHop = -1, 
            int selectedFermentable = -1, 
            int selectedAdjunct = -1, 
            int selectedYeast = -1, 
            int updatedHop = -1, 
            int updatedFermentable = -1, 
            int updatedYeast = -1, 
            int updatedAdjunct = -1)
        {

            /*
             * "Dirty Flag"
             * 
             * If true it will save the data
             * if false it will not sabe the data
             * */
            bool save = false;


            /**********
             * check if the recipe info was changed
             * Only Applicable to updating recipe information
             * */
            if (returnModel != null && returnModel.currentRecipe != null)
            {
                if (returnModel.currentRecipe.name != recipeDetails.name)
                {
                    recipeDetails.name = returnModel.currentRecipe.name;
                    save = true;
                }
                if (returnModel.currentRecipe.style != recipeDetails.style)
                {
                    recipeDetails.style = returnModel.currentRecipe.style;
                    save = true;
                }
                if (returnModel.currentRecipe.description != recipeDetails.description)
                {
                    recipeDetails.description = returnModel.currentRecipe.description;
                    save = true;
                }
                if(returnModel.selectedStyle != currentSelectedStyle)
                {
                    currentSelectedStyle = returnModel.selectedStyle;
                    recipeDetails.style = styleOptions.Where(s => s.idString == currentSelectedStyle).FirstOrDefault();
                    save = true;
                }
            }

            /*
             * Some recipes were being saved with null recipe parameters. 
             * If recipe parameters is null add one, because the math will
             * blow up without it.
             * */
            if (recipeDetails.recipeParameters == null)
            {
                recipeDetails.recipeParameters = new RecipeParameters();
                recipeDetails.recipeParameters.intoFermenterVolume = 1;
                recipeDetails.recipeParameters.ibuCalcType = "basic";
                recipeDetails.recipeParameters.fermentableCalcType = "basic";
                recipeDetails.recipeParameters.ibuBoilTimeCurveFit = -0.04; 
            }

            if(recipeDetails.equipmentProfile == null)
            {
                recipeDetails.equipmentProfile = getDefaultEquipmentProfile();
            }


            if(recipeDetails.recipeStats == null)
            {
                recipeDetails.recipeStats = makeEmptyRecipeStats();
            }
            /*
             * handles selected hop change states.
             * 
             * -1 = no hop change
             * -2 = add hop
             * -3 = delete hop
             * actual value = update current selected hop index.
             * */
            if (selectedHop == -1)
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
            //Add Hop
            else if (selectedHop == -2)
            {
                recipeDetails.hops.Add(makeEmptyHopAddition());
                currentSelectedHop = recipeDetails.hops.Count-1;
                save = true;
            }
            //Delete Hop
            else if (selectedHop == -3)
            {
                recipeDetails.hops.RemoveAt(currentSelectedHop);
                if(currentSelectedHop == recipeDetails.hops.Count)
                {
                    currentSelectedHop--;
                }
                save = true;
            }
            else
            {
                currentSelectedHop = selectedHop;
            }

            /*
             * handles selected fermentable change states.
             * 
             * -1 = no fermentable change
             * -2 = add fermentable
             * -3 = delete fermentable
             * actual value = update current selected fermentable index.
             * */
            if (selectedFermentable == -1)
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
            //Add Fermentable
            else if (selectedFermentable == -2)
            {
                recipeDetails.fermentables.Add(makeEmptyFermentablAddition());
                currentSelectedFermentable = recipeDetails.fermentables.Count - 1;
                save = true;
            }
            //Delete Fermentable
            else if (selectedFermentable == -3)
            {
                recipeDetails.fermentables.RemoveAt(currentSelectedFermentable);
                if (currentSelectedFermentable == recipeDetails.fermentables.Count)
                {
                    currentSelectedFermentable--;
                }
                save = true;
            }
            else
            {
                currentSelectedFermentable = selectedFermentable;
            }

            /*
             * handles selected yeast change states.
             * 
             * -1 = no yeast change
             * -2 = add yeast
             * -3 = delete yeast
             * actual value = update current selected yeast index.
             * */
            if (selectedYeast == -1)
            {
                    selectedYeast = 0;
            }
            //Add yeast
            else if (selectedYeast == -2)
            {
                recipeDetails.yeasts.Add(makeEmptyYeastAddition());
                currentSelectedYeast = recipeDetails.yeasts.Count - 1;
                save = true;
            }
            //Delete yeast
            else if (selectedYeast == -3)
            {
                recipeDetails.yeasts.RemoveAt(currentSelectedYeast);
                if (currentSelectedYeast == recipeDetails.yeasts.Count)
                {
                    currentSelectedYeast--;
                }
                save = true;
            }
            else
            {
                currentSelectedYeast = selectedYeast;
            }

            /*
             * handles selected adjunct change states.
             * 
             * -1 = no adjunct change
             * -2 = add adjunct
             * -3 = delete adjunct
             * actual value = update current selected adjunct index.
             * */
            if (selectedAdjunct == -1)
            {
                selectedAdjunct = currentSelectedAdjunct;//why does it do this?
            }
            //Add Adjunt
            else if (selectedAdjunct == -2)
            {
                recipeDetails.adjuncts.Add(makeEmptyAdjunctAddition());
                currentSelectedAdjunct = recipeDetails.adjuncts.Count - 1;
                save = true;
            }
            //Delete Fermentable
            else if (selectedAdjunct == -3)
            {
                recipeDetails.adjuncts.RemoveAt(currentSelectedAdjunct);
                if (currentSelectedAdjunct == recipeDetails.adjuncts.Count)
                {
                    currentSelectedAdjunct--;
                }
                save = true;
            }
            else
            {
                currentSelectedAdjunct = selectedAdjunct;
            }


            /*
             * handles changing the hop for an addition
             * */
            if (updatedHop != -1)
            {
                if(recipeDetails.hops.Count > 0)
                {
                    recipeDetails.hops[currentSelectedHop].hop = hopOptions[updatedHop];
                }
                else
                {
                    hopAddition h = makeEmptyHopAddition();
                    h.hop = hopOptions[updatedHop];
                    recipeDetails.hops.Add(h);
                    if(currentSelectedHop == -1)
                        currentSelectedHop++;
                }
                save = true;
            }

            /*
             * handles changing the fermentable for an addition
             * */
            if (updatedFermentable != -1)
            {
                if(recipeDetails.fermentables.Count > 0)
                {

                    recipeDetails.fermentables[currentSelectedFermentable].fermentable = fermentableOptions[updatedFermentable];
                }
                else
                {
                    fermentableAddition f = makeEmptyFermentablAddition();
                    f.fermentable = fermentableOptions[updatedFermentable];
                    recipeDetails.fermentables.Add(f);
                    if(currentSelectedFermentable == -1)
                        currentSelectedFermentable++;
                }
                save = true;
            }

            /*
             * handles changing the yeast for an addition
             * */
            if (updatedYeast != -1)
            {
                if (recipeDetails.yeasts.Count > 0)
                {

                    recipeDetails.yeasts[currentSelectedYeast].yeast = yeastOptions[updatedYeast];
                }
                else
                {
                    yeastAddition y = makeEmptyYeastAddition();
                    y.yeast = yeastOptions[updatedYeast];
                    recipeDetails.yeasts.Add(y);
                    if(currentSelectedYeast == -1)
                        currentSelectedYeast++;
                }
                save = true;
            }

            /*
             * handles changing the adjunct for an addition
             * */
            if (updatedAdjunct != -1)
            {
                if (recipeDetails.adjuncts.Count > 0)
                {

                    recipeDetails.adjuncts[updatedAdjunct].adjunct = adjunctOptions[updatedAdjunct];
                }
                else
                {
                    adjunctAddition a = makeEmptyAdjunctAddition();
                    a.adjunct = adjunctOptions[updatedAdjunct];
                    recipeDetails.adjuncts.Add(a);
                    if(currentSelectedAdjunct == -1)
                        currentSelectedAdjunct++;
                }
                save = true;
            }

            /*
             * handles updating fermentable addition information
             * */
            if (returnModel.selectedFermentableAddition != null)
            {
                recipeDetails.fermentables[currentSelectedFermentable] = updateFermentableAddition(recipeDetails.fermentables[currentSelectedFermentable], returnModel.selectedFermentableAddition);
                save = true;
            }

            /*
             * handles updating hop addition information
             * */
            if(returnModel.selectedHopAddition != null)
            {
                recipeDetails.hops[currentSelectedHop] = updateHopAddition(recipeDetails.hops[currentSelectedHop], returnModel.selectedHopAddition);
                save = true;
            }

            /*
             * handles updating adjunct addition information
             * */
            if (returnModel.selectedAdjunctAddition != null)
            {
                recipeDetails.adjuncts[currentSelectedAdjunct] = updateAdjunctAddition(recipeDetails.adjuncts[currentSelectedAdjunct], returnModel.selectedAdjunctAddition);
                save = true;
            }

            /*
             * if the dirty flag is set it saves the recipe information.
             * */
            if (save)
            {
                RecipeResponse RecipeStats = DataAccess.postRecipe(recipeDetails, AppSettings.apiAuthToken);

                recipeDetails.idString = RecipeStats.idString;
                if(RecipeStats != null)
                {
                    recipeDetails.recipeStats = RecipeStats.recipeStats;
                    recipeDetails.lastModifiedGuid = RecipeStats.lastModifiedGuid;
                }
            }
            
            /*
             * Sets and updates the viewmodel information
             * */
            EditorViewModel e = new EditorViewModel();
            e.currentRecipe = recipeDetails;

            if (recipeDetails.hops.Count > 0)
            {
                e.selectedHopAddition = recipeDetails.hops[currentSelectedHop];
            }
            else
            {
                e.selectedHopAddition = makeEmptyHopAddition();
            }


            if (recipeDetails.fermentables.Count > 0)
            {
                e.selectedFermentableAddition = recipeDetails.fermentables[currentSelectedFermentable];
            }
            else
            {
                e.selectedFermentableAddition = makeEmptyFermentablAddition();
            }

            if (recipeDetails.yeasts.Count > 0)
            {
                e.selectedYeastAddition = recipeDetails.yeasts[currentSelectedYeast];
            }
            else
            {
                e.selectedYeastAddition = makeEmptyYeastAddition();
            }

            if (recipeDetails.adjuncts.Count > 0)
            {
                e.selectedAdjunctAddition = recipeDetails.adjuncts[currentSelectedAdjunct];
            }
            else
            {
                e.selectedAdjunctAddition = makeEmptyAdjunctAddition();
            }

            e.selectedHopAdditionIndex = currentSelectedHop;
            e.selectedFermentableAdditionIndex = currentSelectedFermentable;
            e.selectedYeastAdditionIndex = currentSelectedYeast;
            e.selectedAdjunctAdditionIndex = currentSelectedAdjunct;
            e.hopOptions = hopOptions;
            e.fermentableOptions = fermentableOptions;
            e.yeastOptions = yeastOptions;
            e.adjunctOptions = adjunctOptions;

            e.styleOptions = styleOptions;
            e.style = styleOptions.Where(s => s.idString == currentSelectedStyle).FirstOrDefault();
            e.selectedStyle = currentSelectedStyle;

            return View("Views/Home/RecipeView.cshtml", e);
        }

        public hopAddition updateHopAddition(hopAddition oldAddition, hopAddition newAddition)
        {
            oldAddition.amount = newAddition.amount;
            oldAddition.time = newAddition.time;
            oldAddition.type = newAddition.type;
            return oldAddition;
        }

        public fermentableAddition updateFermentableAddition(fermentableAddition oldAddition, fermentableAddition newAddition)
        {
            oldAddition.use = newAddition.use;
            oldAddition.weight = newAddition.weight;
            return oldAddition;
        }

        public adjunctAddition updateAdjunctAddition(adjunctAddition oldAddition, adjunctAddition newAddition)
        {
            oldAddition.amount = newAddition.amount;
            oldAddition.time = newAddition.time;
            oldAddition.timeUnit = newAddition.timeUnit;
            oldAddition.type = newAddition.type;
            oldAddition.unit = newAddition.unit;
            return oldAddition;
        }

        public fermentableAddition makeEmptyFermentablAddition()
        {
            fermentableAddition e = new fermentableAddition();
            e.additionGuid = Guid.NewGuid().ToString();
            e.use = "";
            e.weight = 0;
            e.fermentable = new fermentable();
            e.fermentable.name = "";
            e.fermentable.maltster = "";
            e.fermentable.yield = 0;
            e.fermentable.type = "";
            return e;
        }

        public hopAddition makeEmptyHopAddition()
        {
            hopAddition e = new hopAddition();
            e.additionGuid = Guid.NewGuid().ToString();
            e.amount = 0;
            e.time = 0;
            e.type = "";
            e.hop = new hopbase();
            e.hop.aau = 0;
            e.hop.name = "";
            return e;
        }

        public yeastAddition makeEmptyYeastAddition()
        {
            yeastAddition addition = new yeastAddition();
            addition.additionGuid = Guid.NewGuid().ToString();
            yeast y = new yeast();
            y.attenuation = 0;
            y.name = "";
            y.lab = "";
            y.idString = "";
            addition.yeast = y;
            return addition;
        }

        public adjunctAddition makeEmptyAdjunctAddition()
        {
            adjunctAddition e = new adjunctAddition();
            e.additionGuid = Guid.NewGuid().ToString();
            e.adjunct = new adjunct();
            e.adjunct.name = "";
            e.adjunct.idString = "";
            e.adjunctID = "";
            e.amount = 0;
            e.time = 0;
            e.timeUnit = "";
            e.type = "";
            e.unit = "";
            return e;
        }

        public recipe makeEmptyRecipe()
        {
            recipe emptyRecipe = new recipe();

            emptyRecipe.name = "";
            emptyRecipe.idString = "";
            emptyRecipe.style = new style();
            emptyRecipe.version = 0;
            emptyRecipe.description = "";
            emptyRecipe.clonedFrom = "";
            //set recipeParameters
            emptyRecipe.recipeParameters = new RecipeParameters();
            emptyRecipe.recipeParameters.intoFermenterVolume = 1;
            emptyRecipe.recipeParameters.ibuCalcType = "basic";
            emptyRecipe.recipeParameters.fermentableCalcType = "basic";
            emptyRecipe.recipeParameters.ibuBoilTimeCurveFit = -0.04;

            emptyRecipe.adjuncts = new List<adjunctAddition>();
            emptyRecipe.hops = new List<hopAddition>();
            emptyRecipe.fermentables = new List<fermentableAddition>();
            emptyRecipe.yeasts = new List<yeastAddition>();

            emptyRecipe.recipeStats = makeEmptyRecipeStats();

            emptyRecipe.style.category = "";
            emptyRecipe.style.description = "";
            emptyRecipe.style.examples = "";
            emptyRecipe.style.idString = "";
            emptyRecipe.style.ingredients = "";
            emptyRecipe.style.maxABV = 0;
            emptyRecipe.style.maxCarb = 0;
            emptyRecipe.style.maxColor = 0;
            emptyRecipe.style.maxFG = 0;
            emptyRecipe.style.maxIBU = 0;
            emptyRecipe.style.maxOG = 0;
            emptyRecipe.style.minABV = 0;
            emptyRecipe.style.minCarb = 0;
            emptyRecipe.style.minColor = 0;
            emptyRecipe.style.minFG = 0;
            emptyRecipe.style.minIBU = 0;
            emptyRecipe.style.minOG = 0;
            emptyRecipe.style.name = "";
            emptyRecipe.style.profile = "";

            emptyRecipe.equipmentProfile = getDefaultEquipmentProfile();

            return emptyRecipe;
        }

        public RecipeStatistics makeEmptyRecipeStats()
        {
            RecipeStatistics recipeStats = new RecipeStatistics();
            recipeStats.abv = 0;
            recipeStats.fg = 0;
            recipeStats.ibu = 0;
            recipeStats.og = 0;
            recipeStats.srm = 0;
            return recipeStats;
        }

        public equipmentProfile getDefaultEquipmentProfile()
        {
            equipmentProfile e = new equipmentProfile();
            e.batchSize = (float)5.5;
            e.boilSize = (float)5.5;
            e.createdByUserId = "";
            e.efficiency = (float)75;
            e.intoFermenterVolume = (float)5.5;
            e.name = "default";
            return e;
        }

        [HttpPost]
        public ActionResult ajaxthingtest([FromBody]int hop)
        {
            recipeDetails.hops[currentSelectedHop].hop = hopOptions[hop];
            return View("/Shared/HopGrid", new HopEditorViewModel {hopOptions = hopOptions, allHops = recipeDetails.hops, selectedHopAddition = recipeDetails.hops[currentSelectedHop] });
        }
    }
}
