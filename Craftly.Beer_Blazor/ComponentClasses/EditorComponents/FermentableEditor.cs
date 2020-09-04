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
    public class FermentableEditor : ComponentBase
    {
        [Parameter] public recipe Model { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        [Parameter] public string SessionID { get; set; }
        [Parameter] public FermentableState fermentableState { get; set; }
        //public static int fermentableState.currentSelectedFermentableIndex { get; set; } = 0;

        IEnumerable<fermentable> AllFermentables;
        public IEnumerable<fermentable> FermentableList;

        public string fermentableName = "";

        //public string fermentableState.currentSelectedFermentableID = "";

        public void Save(bool save)
        {
            RecipeResponse r = RecipeHelper.SaveRecipe(Model, save, SessionID);
            Model.recipeStats = r.recipeStats;
            Model.lastModifiedGuid = r.lastModifiedGuid;
            Model.idString = r.idString;
            refreshParent.InvokeAsync("");
        }

        public void resetSelector()
        {
            if (fermentableState.currentSelectedFermentableIndex > Model.fermentables.Count - 1)
            {
                if (Model.fermentables.Count > 0)
                {
                    fermentableState.currentSelectedFermentableIndex = 0;
                }
                else
                {
                    fermentableState.currentSelectedFermentableIndex = -1;
                }
            }
        }

        public void changeSelectedFermentable(string id)
        {
            int i = 0;
            int indexOfFermentable = -1;
            foreach (fermentableAddition fa in Model.fermentables)
            {
                if (id == fa.additionGuid)
                {
                    indexOfFermentable = i;
                    fermentableName = fa.fermentable.name;
                    fermentableState.currentSelectedFermentableID = fa.fermentable.idString;
                    break;
                }
                i++;
            }

            if (indexOfFermentable != -1)
            {
                fermentableState.currentSelectedFermentableIndex = indexOfFermentable;
            }

        }

        protected override void OnInitialized()
        {
            if (Model.adjuncts.Count > 0)
            {
                fermentableState.currentSelectedFermentableIndex = 0;
            }
            else
            {
                fermentableState.currentSelectedFermentableIndex = -1;
            }
            resetSelector();
            AllFermentables = RecipeHelper.GetAllFermentables(SessionID);
            FermentableList = AllFermentables;
            fermentableState.currentSelectedFermentableID = findFermentableIDFromSelecteFermentable();
            

            if (Model.fermentables.Count != 0 && fermentableState.currentSelectedFermentableIndex != -1)
            {
                fermentableName = Model.fermentables[fermentableState.currentSelectedFermentableIndex].fermentable.name;
            }
            else
            {
                fermentableName = "";
            }

        }
        
        public void ChangeFermentableWeight(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.fermentables[fermentableState.currentSelectedFermentableIndex].weight = output;
            }
            Save(false);
        }
        public void ChangeFermentableYield(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.fermentables[fermentableState.currentSelectedFermentableIndex].fermentable.yield = output;
            }
            Save(false);
        }

        public List<hopbase> loadAllHops()
        {
            return RecipeHelper.GetAllHops(SessionID);
        }

        public void Change(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            if (Model.fermentables.Count == 0)
            {
                fermentable hopw = new fermentable();
                fermentableAddition ha = new fermentableAddition();
                Model.fermentables.Add(ha);
                Model.fermentables[0].fermentable = hopw;
                fermentableState.currentSelectedFermentableIndex = 0;
            }
            fermentableState.currentSelectedFermentableID = value.ToString();
            Model.fermentables[fermentableState.currentSelectedFermentableIndex].fermentable = AllFermentables.Where(x => x.idString == value).FirstOrDefault();
            Model.fermentables[fermentableState.currentSelectedFermentableIndex].fermentableID = value.ToString();

            if (Model.fermentables.Count != 0)
            {
                fermentableName = Model.fermentables[fermentableState.currentSelectedFermentableIndex].fermentable.name;
            }
            else
            {
                fermentableName = "";
            }

            Save(false);

            StateHasChanged();
        }

        public string findFermentableIDFromSelecteFermentable()
        {
            resetSelector();
            if (fermentableState.currentSelectedFermentableIndex != -1 && Model.fermentables.Count != 0)
            {
                fermentable currentSelection = AllFermentables.Where(x => x.name == Model.fermentables[fermentableState.currentSelectedFermentableIndex].fermentable.name).FirstOrDefault();
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

        public void LoadData(LoadDataArgs args)
        {
            var query = AllFermentables.AsQueryable();

            if (!string.IsNullOrEmpty(args.Filter))
            {
                query = query.Where(c => c.name.ToLower().Contains(args.Filter.ToLower()));
            }

            FermentableList = query.ToList();

            InvokeAsync(StateHasChanged);
        }

        public void AddFermentable()
        {
            fermentableAddition fa = RecipeTools.makeEmptyFermentablAddition();//new fermentableAddition();
            fermentableState.currentSelectedFermentableID = "";

            if (Model.fermentables.Count > 0)
            {
                Model.fermentables.Insert(fermentableState.currentSelectedFermentableIndex + 1, fa);
                fermentableState.currentSelectedFermentableIndex++;
            }
            else
            {
                Model.fermentables.Add(fa);
                fermentableState.currentSelectedFermentableIndex = 0;
            }
            Save(false);
        }

        public void DeleteFermentable()
        {
            if (Model.fermentables.Count == 0)
            { return; }

            Model.fermentables.RemoveAt(fermentableState.currentSelectedFermentableIndex);
            if (fermentableState.currentSelectedFermentableIndex == Model.fermentables.Count)
            {
                fermentableState.currentSelectedFermentableIndex--;
            }
            Save(false);
        }

    }
}
