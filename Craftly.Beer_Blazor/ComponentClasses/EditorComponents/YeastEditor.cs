using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;
using Beernet_Lib.Tools;
using Craftly.Beer_Blazor.ComponentClasses.ComponentStateClasses;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class YeastEditor : ComponentBase
    {
        [Parameter] public recipe Model { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        [Parameter] public string SessionID { get; set; }
        [Parameter] public YeastState yeastState { get; set; }

        IEnumerable<yeast> AllYeasts;
        public IEnumerable<yeast> YeastList;

        //public static int yeastState.currentSelectedYeastIndex { get; set; } = 0;
        //public string yeastState.currentSelectedYeastID = "";
        public string yeastName = "";

        public void changeSelectedYeast(string id)
        {

            int i = 0;
            int indexOfYeast = -1;
            foreach (yeastAddition ya in Model.yeasts)
            {
                if (id == ya.additionGuid)
                {
                    indexOfYeast = i;
                    yeastName = ya.yeast.name;
                    break;
                }
                i++;
            }

            if (indexOfYeast != -1)
            {
                yeastState.currentSelectedYeastIndex = indexOfYeast;
            }

        }
        public void Save(bool save)
        {
            RecipeResponse r = RecipeHelper.SaveRecipe(Model, save, SessionID);
            Model.recipeStats = r.recipeStats;
            Model.lastModifiedGuid = r.lastModifiedGuid;
            Model.idString = r.idString;
            refreshParent.InvokeAsync("");
        }

        protected override void OnInitialized()
        {
            if (Model.yeasts.Count > 0)
            {
                yeastState.currentSelectedYeastIndex = 0;
            }
            else
            {
                yeastState.currentSelectedYeastIndex = -1;
            }
            resetSelector();
            AllYeasts = RecipeHelper.GetAllYeasts(SessionID);
            YeastList = AllYeasts;
            yeastState.currentSelectedYeastID = findYeastIDFromSelectedYeast();


            if (Model.yeasts.Count != 0 && yeastState.currentSelectedYeastIndex != -1)
            {
                yeastName = Model.yeasts[yeastState.currentSelectedYeastIndex].yeast.name;
            }
            else
            {
                yeastName = "";
            }
        }

        public List<hopbase> loadAllHops()
        {
            return RecipeHelper.GetAllHops(SessionID);
        }

        public void Change(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            if (Model.yeasts[yeastState.currentSelectedYeastIndex].yeast != null)
            {
                Model.yeasts[yeastState.currentSelectedYeastIndex].yeast = AllYeasts.Where(x => x.idString == value).FirstOrDefault();
            }

            if (Model.yeasts.Count != 0)
            {
                yeastName = Model.yeasts[yeastState.currentSelectedYeastIndex].yeast.name;
            }
            else
            {
                yeastName = "";
            }

            //save to api
            Save(false);

            StateHasChanged();
        }
        public string findYeastIDFromSelectedYeast()
        {
            resetSelector();
            if (yeastState.currentSelectedYeastIndex != -1 && Model.yeasts.Count != 0)
            {
                yeast currentSelection = AllYeasts.Where(x => x.name == Model.yeasts[yeastState.currentSelectedYeastIndex].yeast.name).FirstOrDefault();
                if (currentSelection == null)
                {
                    return "-1";
                }
                else
                {
                    return currentSelection.idString;
                }
            }
            else
            {
                return "-1";
            }
        }

        public void resetSelector()
        {
            if (yeastState.currentSelectedYeastIndex > Model.yeasts.Count - 1)
            {
                if (Model.yeasts.Count > 0)
                {
                    yeastState.currentSelectedYeastIndex = 0;
                }
                else
                {
                    yeastState.currentSelectedYeastIndex = -1;
                }
            }
        }

        public void LoadData(LoadDataArgs args)
        {
            var query = AllYeasts.AsQueryable();

            if (!string.IsNullOrEmpty(args.Filter))
            {
                query = query.Where(c => c.name.ToLower().Contains(args.Filter.ToLower()));
            }

            YeastList = query.ToList();

            InvokeAsync(StateHasChanged);
        }

        public void AddYeast()
        {
            yeastAddition ya = RecipeTools.makeEmptyYeastAddition();
            yeastState.currentSelectedYeastID = "";

            if (Model.yeasts.Count > 0)
            {
                Model.yeasts.Insert(yeastState.currentSelectedYeastIndex + 1, ya);
                yeastState.currentSelectedYeastIndex++;
            }
            else
            {
                Model.yeasts.Add(ya);
                yeastState.currentSelectedYeastIndex = 0;
            }
            Save(false);
        }

        public void DeleteYeast()
        {
            if (Model.yeasts.Count == 0)
            { return; }
            Model.yeasts.RemoveAt(yeastState.currentSelectedYeastIndex);
            if (yeastState.currentSelectedYeastIndex == Model.yeasts.Count)
            {
                yeastState.currentSelectedYeastIndex--;
            }
            Save(false);
        }

    }
}
