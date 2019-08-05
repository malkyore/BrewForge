using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Beernet_Lib.Tools;
using Brewforge;
using Brewforge.Controllers;
using Brewforge.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BrewForge.Controllers
{

    public class AdminController : BaseController
    {
        private IHostingEnvironment hostingEnvironment;

        public AdminController(IOptions<AppSettings> settings, IHostingEnvironment env) : base(settings)
        {

        }

        public static int currentSelectedHop { get; set; }
        public static int currentSelectedFermentable { get; set; }
        public static int currentSelectedYeast { get; set; }
        public static int currentSelectedAdjunct { get; set; }
        public static int currentSelectedStyle { get; set; }
        public static List<hopbase> hopOptions { get; set; }
        public static List<fermentable> fermentableOptions { get; set; }
        public static List<yeast> yeastOptions { get; set; }
        public static List<adjunct> adjunctOptions { get; set; }
        public static List<style> styleOptions { get; set; }
        // GET: /<controller>/
        public IActionResult Index()
        {
            hopOptions = DataAccess.getAllHops(AppSettings.apiLink, AppSettings.apiAuthToken);
            fermentableOptions = DataAccess.getAllFermentables(AppSettings.apiLink, AppSettings.apiAuthToken);
            yeastOptions = DataAccess.getAllYeasts(AppSettings.apiLink, AppSettings.apiAuthToken);
            adjunctOptions = DataAccess.getAllAdjuncts(AppSettings.apiLink, AppSettings.apiAuthToken);
            styleOptions = DataAccess.getAllStyles(AppSettings.apiLink, AppSettings.apiAuthToken);
            currentSelectedHop = 0;
            currentSelectedFermentable = 0;
            currentSelectedStyle = 0;
            currentSelectedYeast = 0;
            currentSelectedAdjunct = 0;

            IngredientManagerViewModel model = new IngredientManagerViewModel();
            model.hopOptions = hopOptions;
            model.fermentableOptions = fermentableOptions;
            model.yeastOptions = yeastOptions;
            model.adjunctOptions = adjunctOptions;
            model.styleOptions = styleOptions;
            model.selectedAdjunctIndex = currentSelectedAdjunct;
            model.selectedFermentableIndex = currentSelectedFermentable;
            model.selectedHopIndex = currentSelectedFermentable;
            model.selectedStyleIndex = currentSelectedStyle;
            model.selectedYeastIndex = currentSelectedYeast;
            return View("Views/Admin/Index.cshtml",model);
        }

        public IActionResult IngredientManager(int selectedHop = -1, IngredientManagerViewModel returnModel = null, hopbase updatedHop = null)
        {
            if(hopOptions.Count == 0)
            {
                hopOptions = DataAccess.getAllHops(AppSettings.apiLink, AppSettings.apiAuthToken);
            }
            if (fermentableOptions.Count == 0)
            {
                fermentableOptions = DataAccess.getAllFermentables(AppSettings.apiLink, AppSettings.apiAuthToken);

            }
            if (yeastOptions.Count == 0)
            {
                yeastOptions = DataAccess.getAllYeasts(AppSettings.apiLink, AppSettings.apiAuthToken);
            }
            if (adjunctOptions.Count == 0)
            {
                adjunctOptions = DataAccess.getAllAdjuncts(AppSettings.apiLink, AppSettings.apiAuthToken);
            }
            if (styleOptions.Count == 0)
            {
                styleOptions = DataAccess.getAllStyles(AppSettings.apiLink, AppSettings.apiAuthToken);
            }
            if(selectedHop != -1)
            {
                currentSelectedHop = selectedHop;
            }

            if(returnModel != null)
            {
                if(returnModel.hopOptions != null && returnModel.hopOptions.Count > 0)
                {
                    hopOptions[currentSelectedHop] = returnModel.hopOptions[0];
                }
            }

                currentSelectedFermentable = 0;
                currentSelectedStyle = 0;
                currentSelectedYeast = 0;
                currentSelectedAdjunct = 0;

                IngredientManagerViewModel model = new IngredientManagerViewModel();
                model.hopOptions = hopOptions;
                model.fermentableOptions = fermentableOptions;
                model.yeastOptions = yeastOptions;
                model.adjunctOptions = adjunctOptions;
                model.styleOptions = styleOptions;
                model.selectedAdjunctIndex = currentSelectedAdjunct;
                model.selectedFermentableIndex = currentSelectedFermentable;
                model.selectedHopIndex = currentSelectedHop;
                model.selectedStyleIndex = currentSelectedStyle;
                model.selectedYeastIndex = currentSelectedYeast;
                return View("Views/Admin/Index.cshtml", model);
        }

    }
}
