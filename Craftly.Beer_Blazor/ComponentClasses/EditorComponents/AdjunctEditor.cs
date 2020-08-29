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
    public class AdjunctEditor : ComponentBase
    {
        [Parameter]
        public recipe Model { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        public static int selectedAdjunctAddition { get; set; } = 0;

        IEnumerable<adjunct> AllAdjuncts;
        public IEnumerable<adjunct> AdjunctList;

        public string adjunctName = "";
        public string selectedAdjunctID = "";

        public void changeSelectedAdjunct(string id)
        {
            int i = 0;
            int indexOfAdjunct = -1;
            foreach (adjunctAddition aa in Model.adjuncts)
            {
                if (id == aa.additionGuid)
                {
                    indexOfAdjunct = i;
                    adjunctName = aa.adjunct.name;
                    selectedAdjunctID = aa.adjunct.idString;
                    break;
                }
                i++;
            }

            if (indexOfAdjunct != -1)
            {
                selectedAdjunctAddition = indexOfAdjunct;
            }

        }
        public void Save(bool save)
        {
            RecipeResponse r = RecipeHelper.SaveRecipe(Model, save);
            Model.recipeStats = r.recipeStats;
            Model.lastModifiedGuid = r.lastModifiedGuid;
            refreshParent.InvokeAsync("");
        }

        public void resetSelector()
        {
            if(selectedAdjunctAddition > Model.adjuncts.Count - 1)
            {
                if (Model.adjuncts.Count > 0)
                {
                    selectedAdjunctAddition = 0;
                }
                else
                {
                    selectedAdjunctAddition = -1;
                }
            }
        }

        protected override void OnInitialized()
        {
            if (Model.adjuncts.Count > 0)
            {
                selectedAdjunctAddition = 0;
            }
            else
            {
                selectedAdjunctAddition = -1;
            }
            resetSelector();
            AllAdjuncts = RecipeHelper.GetAllAdjuncts();
            AdjunctList = AllAdjuncts;
            selectedAdjunctID = findAdjunctIDFromSelecteAdjunct();

            if (Model.adjuncts.Count != 0)
            {
                adjunctName = Model.adjuncts[selectedAdjunctAddition].adjunct.name;
            }
            else
            {
                selectedAdjunctAddition = -1;
                adjunctName = "";
            }
        }

        public List<adjunct> loadAllAdjuncts()
        {
            return RecipeHelper.GetAllAdjuncts();
        }

        public void Change(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            Model.adjuncts[selectedAdjunctAddition].adjunct = AllAdjuncts.Where(x => x.idString == value).FirstOrDefault();
            Model.adjuncts[selectedAdjunctAddition].adjunctID = value.ToString();

            selectedAdjunctID = value.ToString();

            if (Model.adjuncts.Count != 0)
            {
                adjunctName = Model.adjuncts[selectedAdjunctAddition].adjunct.name;
            }
            else
            {
                adjunctName = "";
            }

            //save to api
            Save(false);

            StateHasChanged();
        }

        public string findAdjunctIDFromSelecteAdjunct()
        {
            resetSelector();
            if (selectedAdjunctAddition != -1 && Model.adjuncts.Count != 0)
            {
                adjunct currentSelection = AllAdjuncts.Where(x => x.name == Model.adjuncts[selectedAdjunctAddition].adjunct.name).FirstOrDefault();
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
            var query = AllAdjuncts.AsQueryable();

            if (!string.IsNullOrEmpty(args.Filter))
            {
                query = query.Where(c => c.name.ToLower().Contains(args.Filter.ToLower()));
            }

            AdjunctList = query.ToList();

            InvokeAsync(StateHasChanged);
        }

        
        public void ChangeAdjunctAmount(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.adjuncts[selectedAdjunctAddition].amount = output;
            }
            Save(false);
        }
        public void ChangeAdjunctUnit(object value, string name)
        {
                Model.adjuncts[selectedAdjunctAddition].unit = value.ToString();
            Save(false);
        }

        public void ChangeAdjunctTime(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.adjuncts[selectedAdjunctAddition].time = output;
            }
            Save(false);
        }

        public void ChangeAdjunctTimeUnit(object value, string name)
        {
                Model.adjuncts[selectedAdjunctAddition].timeUnit = value.ToString();
            Save(false);
        }
        public void ChangeAdjunctType(object value, string name)
        {
                Model.adjuncts[selectedAdjunctAddition].type = value.ToString();
            Save(false);
        }

        public void AddAdjunct()
        {
            adjunctAddition aa = RecipeTools.makeEmptyAdjunctAddition();//new adjunctAddition();
            //adjunct adjunct = new adjunct();
            //aa.adjunct = adjunct;
            selectedAdjunctID = "";

            if (Model.adjuncts.Count > 0)
            {
                Model.adjuncts.Insert(selectedAdjunctAddition + 1, aa);
                selectedAdjunctAddition++;
            }
            else
            {
                Model.adjuncts.Add(aa);
                selectedAdjunctAddition++;
            }
            Save(false);
        }

        public void DeleteAdjunct()
        {
            if (Model.adjuncts.Count == 0)
            { return; }
            Model.adjuncts.RemoveAt(selectedAdjunctAddition);
            if (selectedAdjunctAddition == Model.adjuncts.Count)
            {
                selectedAdjunctAddition--;
            }
            Save(false);
        }
    }
}
