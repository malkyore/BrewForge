using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;
using Beernet_Lib.Tools;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class FermentableEditor : ComponentBase
    {
        [Parameter]
        public recipe Model { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        [Parameter]
        public string SessionID { get; set; }
        public static int selectedFermentableAddition { get; set; } = 0;

        IEnumerable<fermentable> AllFermentables;
        public IEnumerable<fermentable> FermentableList;

        public string fermentableName = "";

        public string selectedFermentableID = "";

        public void Save(bool save)
        {
            RecipeResponse r = RecipeHelper.SaveRecipe(Model, save, SessionID);
            Model.recipeStats = r.recipeStats;
            Model.lastModifiedGuid = r.lastModifiedGuid;
            refreshParent.InvokeAsync("");
        }

        public void resetSelector()
        {
            if (selectedFermentableAddition > Model.fermentables.Count - 1)
            {
                if (Model.fermentables.Count > 0)
                {
                    selectedFermentableAddition = 0;
                }
                else
                {
                    selectedFermentableAddition = -1;
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
                    selectedFermentableID = fa.fermentable.idString;
                    break;
                }
                i++;
            }

            if (indexOfFermentable != -1)
            {
                selectedFermentableAddition = indexOfFermentable;
            }

        }

        protected override void OnInitialized()
        {
            if (Model.adjuncts.Count > 0)
            {
                selectedFermentableAddition = 0;
            }
            else
            {
                selectedFermentableAddition = -1;
            }
            resetSelector();
            AllFermentables = RecipeHelper.GetAllFermentables(SessionID);
            FermentableList = AllFermentables;
            selectedFermentableID = findFermentableIDFromSelecteFermentable();
            

            if (Model.fermentables.Count != 0 && selectedFermentableAddition != -1)
            {
                fermentableName = Model.fermentables[selectedFermentableAddition].fermentable.name;
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
                Model.fermentables[selectedFermentableAddition].weight = output;
            }
            Save(false);
        }
        public void ChangeFermentableYield(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.fermentables[selectedFermentableAddition].fermentable.yield = output;
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

            if (Model.hops.Count == 0)
            {
                fermentable hopw = new fermentable();
                fermentableAddition ha = new fermentableAddition();
                Model.fermentables.Add(ha);
                Model.fermentables[0].fermentable = hopw;
                selectedFermentableAddition = 0;
            }
            selectedFermentableID = value.ToString();
            Model.fermentables[selectedFermentableAddition].fermentable = AllFermentables.Where(x => x.idString == value).FirstOrDefault();
            Model.fermentables[selectedFermentableAddition].fermentableID = value.ToString();

            if (Model.fermentables.Count != 0)
            {
                fermentableName = Model.fermentables[selectedFermentableAddition].fermentable.name;
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
            if (selectedFermentableAddition != -1 && Model.fermentables.Count != 0)
            {
                fermentable currentSelection = AllFermentables.Where(x => x.name == Model.fermentables[selectedFermentableAddition].fermentable.name).FirstOrDefault();
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
            selectedFermentableID = "";

            if (Model.fermentables.Count > 0)
            {
                Model.fermentables.Insert(selectedFermentableAddition + 1, fa);
                selectedFermentableAddition++;
            }
            else
            {
                Model.fermentables.Add(fa);
                selectedFermentableAddition++;
            }
            Save(false);
        }

        public void DeleteFermentable()
        {
            if (Model.fermentables.Count == 0)
            { return; }

            Model.fermentables.RemoveAt(selectedFermentableAddition);
            if (selectedFermentableAddition == Model.fermentables.Count)
            {
                selectedFermentableAddition--;
            }
            Save(false);
        }

    }
}
