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
    public class BrewlogController : BaseController
    {
        private IHostingEnvironment hostingEnvironment;

        public BrewlogController(IOptions<AppSettings> settings, IHostingEnvironment env) : base(settings)
        {
            
        }
        
        //Original Recipe from recipe list
        public static recipe originalRecipeDetails { get; set; }

        //Rectified Recipe 
        public static recipe recipeDetails { get; set; }

        public static BrewLog brewlogDetails { get; set; }

        public static List<BrewLog> allBrewLogs { get; set; }

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

        [HttpGet()]
        public virtual IActionResult Index(string selectedRecipe = "-1")
        {
            allBrewLogs = DataAccess.getAllBrewLogs(AppSettings.apiLink, AppSettings.apiAuthToken);

            BrewlogDashboardModel model = new BrewlogDashboardModel();
            model.brewLogs = allBrewLogs;
            return View(model);
        }

        public virtual IActionResult openBrewLog()
        {
            allBrewLogs = DataAccess.getAllBrewLogs(AppSettings.apiLink, AppSettings.apiAuthToken);
            BrewloggerModel model = new BrewloggerModel();
            model.brewLog = allBrewLogs[0];

            return View("Views/Brewlog/Brewlogger.cshtml", model);
        }


        /*
         * Opens the selected recipe 
         * */
        public virtual ActionResult openRectifiedRecipe()
        {
                EditorViewModel e = new EditorViewModel();
                currentSelectedFermentable = 0;
                currentSelectedHop = 0;
                currentSelectedYeast = 0;
                currentSelectedAdjunct = 0;


            //recipeDetails = DataAccess.getRecipeDetails(AppSettings.apiLink + AppSettings.recipeEndpoint, AppSettings.apiAuthToken, openRecipe);

            allBrewLogs = DataAccess.getAllBrewLogs(AppSettings.apiLink, AppSettings.apiAuthToken);
                e.currentRecipe = recipeDetails;
                if (recipeDetails.hops.Count > 0)
                {
                    e.selectedHopAddition = recipeDetails.hops[0];
                }
                else
                {
                    e.selectedHopAddition = RecipeTools.makeEmptyHopAddition();
                }

                if (recipeDetails.fermentables.Count > 0)
                {
                    e.selectedFermentableAddition = recipeDetails.fermentables[0];
                }
                else
                {
                    e.selectedFermentableAddition = RecipeTools.makeEmptyFermentablAddition();
                }

                if (recipeDetails.yeasts.Count > 0)
                {
                    e.selectedYeastAddition = recipeDetails.yeasts[0];
                }
                else
                {
                    e.selectedYeastAddition = RecipeTools.makeEmptyYeastAddition();
                }

                if (recipeDetails.adjuncts.Count > 0)
                {
                    e.selectedAdjunctAddition = recipeDetails.adjuncts[0];
                }
                else
                {
                    e.selectedAdjunctAddition = RecipeTools.makeEmptyAdjunctAddition();
                }

                hopOptions = DataAccess.getAllHops(AppSettings.apiLink, AppSettings.apiAuthToken);
                fermentableOptions = DataAccess.getAllFermentables(AppSettings.apiLink, AppSettings.apiAuthToken);
                yeastOptions = DataAccess.getAllYeasts(AppSettings.apiLink, AppSettings.apiAuthToken);
                adjunctOptions = DataAccess.getAllAdjuncts(AppSettings.apiLink, AppSettings.apiAuthToken);
                styleOptions = DataAccess.getAllStyles(AppSettings.apiLink, AppSettings.apiAuthToken);

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
                    e.selectedStyle = styleOptions[0].idString;
                }
                else
                {
                    e.style = recipeDetails.style;
                    e.selectedStyle = recipeDetails.style.idString;
                }
            return View("Views/Recipe/Editor.cshtml", e);
        }

        public virtual IActionResult editRecipe (
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
                recipeDetails.equipmentProfile = RecipeTools.getDefaultEquipmentProfile();
            }


            if(recipeDetails.recipeStats == null)
            {
                recipeDetails.recipeStats = RecipeTools.makeEmptyRecipeStats();
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
                recipeDetails.hops.Add(RecipeTools.makeEmptyHopAddition());
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
                recipeDetails.fermentables.Add(RecipeTools.makeEmptyFermentablAddition());
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
                recipeDetails.yeasts.Add(RecipeTools.makeEmptyYeastAddition());
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
                recipeDetails.adjuncts.Add(RecipeTools.makeEmptyAdjunctAddition());
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
                    hopAddition h = RecipeTools.makeEmptyHopAddition();
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
                    fermentableAddition f = RecipeTools.makeEmptyFermentablAddition();
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
                    yeastAddition y = RecipeTools.makeEmptyYeastAddition();
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
                    adjunctAddition a = RecipeTools.makeEmptyAdjunctAddition();
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
                recipeDetails.fermentables[currentSelectedFermentable] = RecipeTools.updateFermentableAddition(recipeDetails.fermentables[currentSelectedFermentable], returnModel.selectedFermentableAddition);
                save = true;
            }

            /*
             * handles updating hop addition information
             * */
            if(returnModel.selectedHopAddition != null)
            {
                recipeDetails.hops[currentSelectedHop] = RecipeTools.updateHopAddition(recipeDetails.hops[currentSelectedHop], returnModel.selectedHopAddition);
                save = true;
            }

            /*
             * handles updating adjunct addition information
             * */
            if (returnModel.selectedAdjunctAddition != null)
            {
                recipeDetails.adjuncts[currentSelectedAdjunct] = RecipeTools.updateAdjunctAddition(recipeDetails.adjuncts[currentSelectedAdjunct], returnModel.selectedAdjunctAddition);
                save = true;
            }

            /*
             * if the dirty flag is set it saves the recipe information.
             * */
            if (save)
            {
                RecipeResponse RecipeStats = DataAccess.postRecipe(recipeDetails, AppSettings.apiLink, AppSettings.apiAuthToken);

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
                e.selectedHopAddition = RecipeTools.makeEmptyHopAddition();
            }


            if (recipeDetails.fermentables.Count > 0)
            {
                e.selectedFermentableAddition = recipeDetails.fermentables[currentSelectedFermentable];
            }
            else
            {
                e.selectedFermentableAddition = RecipeTools.makeEmptyFermentablAddition();
            }

            if (recipeDetails.yeasts.Count > 0)
            {
                e.selectedYeastAddition = recipeDetails.yeasts[currentSelectedYeast];
            }
            else
            {
                e.selectedYeastAddition = RecipeTools.makeEmptyYeastAddition();
            }

            if (recipeDetails.adjuncts.Count > 0)
            {
                e.selectedAdjunctAddition = recipeDetails.adjuncts[currentSelectedAdjunct];
            }
            else
            {
                e.selectedAdjunctAddition = RecipeTools.makeEmptyAdjunctAddition();
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

            return View("Views/Recipe/Editor.cshtml", e);
        }

        [HttpPost]
        public ActionResult ajaxthingtest([FromBody]int hop)
        {
            recipeDetails.hops[currentSelectedHop].hop = hopOptions[hop];
            return View("/Shared/HopGrid", new HopEditorViewModel {hopOptions = hopOptions, allHops = recipeDetails.hops, selectedHopAddition = recipeDetails.hops[currentSelectedHop] });
        }
    }
}
