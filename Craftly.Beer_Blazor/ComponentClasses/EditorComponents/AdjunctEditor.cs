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
    public class AdjunctEditor : ComponentBase
    {
        [Parameter]  public recipe Model { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        [Parameter] public string SessionID { get; set; }

        [Parameter] public AdjunctState adjunctState { get; set; }
        //public static int adjunctState.currentSelectedAdjunctIndex { get; set; } = 0;

        IEnumerable<adjunct> AllAdjuncts;
        public IEnumerable<adjunct> AdjunctList;

        public string adjunctName = "";
        //public string adjunctState.currentSelectedAdjunctID = "";

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
                    adjunctState.currentSelectedAdjunctID = aa.adjunct.idString;
                    break;
                }
                i++;
            }

            if (indexOfAdjunct != -1)
            {
                adjunctState.currentSelectedAdjunctIndex = indexOfAdjunct;
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

        public void resetSelector()
        {
            if(adjunctState.currentSelectedAdjunctIndex > Model.adjuncts.Count - 1)
            {
                if (Model.adjuncts.Count > 0)
                {
                    adjunctState.currentSelectedAdjunctIndex = 0;
                }
                else
                {
                    adjunctState.currentSelectedAdjunctIndex = -1;
                }
            }
        }

        protected override void OnInitialized()
        {
            if (Model.adjuncts.Count > 0)
            {
                adjunctState.currentSelectedAdjunctIndex = 0;
            }
            else
            {
                adjunctState.currentSelectedAdjunctIndex = -1;
            }
            resetSelector();
            AllAdjuncts = RecipeHelper.GetAllAdjuncts(SessionID);
            AdjunctList = AllAdjuncts;
            adjunctState.currentSelectedAdjunctID = findAdjunctIDFromSelecteAdjunct();

            if (Model.adjuncts.Count != 0)
            {
                adjunctName = Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].adjunct.name;
            }
            else
            {
                adjunctState.currentSelectedAdjunctIndex = -1;
                adjunctName = "";
            }
        }

        public List<adjunct> loadAllAdjuncts()
        {
            return RecipeHelper.GetAllAdjuncts(SessionID);
        }

        public void Change(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].adjunct = AllAdjuncts.Where(x => x.idString == value).FirstOrDefault();
            Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].adjunctID = value.ToString();

            adjunctState.currentSelectedAdjunctID = value.ToString();

            if (Model.adjuncts.Count != 0)
            {
                adjunctName = Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].adjunct.name;
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
            if (adjunctState.currentSelectedAdjunctIndex != -1 && Model.adjuncts.Count != 0)
            {
                adjunct currentSelection = AllAdjuncts.Where(x => x.name == Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].adjunct.name).FirstOrDefault();
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
                Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].amount = output;
            }
            Save(false);
        }
        public void ChangeAdjunctUnit(object value, string name)
        {
                Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].unit = value.ToString();
            Save(false);
        }

        public void ChangeAdjunctTime(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].time = output;
            }
            Save(false);
        }

        public void ChangeAdjunctTimeUnit(object value, string name)
        {
                Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].timeUnit = value.ToString();
            Save(false);
        }
        public void ChangeAdjunctType(object value, string name)
        {
                Model.adjuncts[adjunctState.currentSelectedAdjunctIndex].type = value.ToString();
            Save(false);
        }

        public void AddAdjunct()
        {
            adjunctAddition aa = RecipeTools.makeEmptyAdjunctAddition();//new adjunctAddition();
            //adjunct adjunct = new adjunct();
            //aa.adjunct = adjunct;
            adjunctState.currentSelectedAdjunctID = "";

            if (Model.adjuncts.Count > 0)
            {
                Model.adjuncts.Insert(adjunctState.currentSelectedAdjunctIndex + 1, aa);
                adjunctState.currentSelectedAdjunctIndex++;
            }
            else
            {
                Model.adjuncts.Add(aa);
                adjunctState.currentSelectedAdjunctIndex = 0;
            }
            Save(false);
        }

        public void DeleteAdjunct()
        {
            if (Model.adjuncts.Count == 0)
            { return; }
            Model.adjuncts.RemoveAt(adjunctState.currentSelectedAdjunctIndex);
            if (adjunctState.currentSelectedAdjunctIndex == Model.adjuncts.Count)
            {
                adjunctState.currentSelectedAdjunctIndex--;
            }
            Save(false);
        }
    }
}
