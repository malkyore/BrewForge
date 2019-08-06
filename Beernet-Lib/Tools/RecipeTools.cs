using Beernet_Lib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Beernet_Lib.Tools
{
    public static class RecipeTools
    {
        public static hopAddition updateHopAddition(hopAddition oldAddition, hopAddition newAddition)
        {
            oldAddition.amount = newAddition.amount;
            oldAddition.time = newAddition.time;
            oldAddition.type = newAddition.type;
            return oldAddition;
        }

        public static fermentableAddition updateFermentableAddition(fermentableAddition oldAddition, fermentableAddition newAddition)
        {
            oldAddition.use = newAddition.use;
            oldAddition.weight = newAddition.weight;
            return oldAddition;
        }

        public static adjunctAddition updateAdjunctAddition(adjunctAddition oldAddition, adjunctAddition newAddition)
        {
            oldAddition.amount = newAddition.amount;
            oldAddition.time = newAddition.time;
            oldAddition.timeUnit = newAddition.timeUnit;
            oldAddition.type = newAddition.type;
            oldAddition.unit = newAddition.unit;
            return oldAddition;
        }

        public static fermentableAddition makeEmptyFermentablAddition()
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

        public static hopAddition makeEmptyHopAddition()
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

        public static yeastAddition makeEmptyYeastAddition()
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

        public static adjunctAddition makeEmptyAdjunctAddition()
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

        public static recipe makeEmptyRecipe(string userID)
        {
            recipe emptyRecipe = new recipe();

            emptyRecipe.createdByUserID = userID;

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

        public static RecipeStatistics makeEmptyRecipeStats()
        {
            RecipeStatistics recipeStats = new RecipeStatistics();
            recipeStats.abv = 0;
            recipeStats.fg = 0;
            recipeStats.ibu = 0;
            recipeStats.og = 0;
            recipeStats.srm = 0;
            return recipeStats;
        }

        public static equipmentProfile getDefaultEquipmentProfile()
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
    }
}
