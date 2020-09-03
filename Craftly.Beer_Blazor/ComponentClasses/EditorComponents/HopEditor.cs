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
    public class HopEditor : ComponentBase
    {
        public static string operatorvalue = "";
        [Parameter]
        public recipe Model { get; set; }
        [CascadingParameter(Name = "SessionID")]
        protected string SessionID { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }

        IEnumerable<hopbase> AllHops;
        public IEnumerable<hopbase> HopList;

        public string hopName = "";
        public string hopUse = "";
        public string selectedHopID = "";

        public List<string> HopUses = new List<string>{ "Boil", "Whirlpool", "Dry Hop" };

        public static int selectedHopAddition { get; set; } = 0;

        public void resetSelector()
        {
            if (selectedHopAddition > Model.hops.Count - 1)
            {
                if (Model.hops.Count > 0)
                {
                    selectedHopAddition = 0;
                }
                else
                {
                    selectedHopAddition = -1;
                }
            }
        }

        public void changeSelectedHop(string id)
        {
            int i = 0;
            int indexOfHop = -1;
            selectedHopID = id;
            foreach(hopAddition ha in Model.hops)
            {
                if(id == ha.additionGuid)
                {
                    indexOfHop = i;
                    hopName = ha.hop.name;
                    break;
                }
                i++;
            }

            if(indexOfHop != -1)
            {
                selectedHopAddition = indexOfHop;
            }
            Save(false);
        }

        protected override void OnInitialized()
        {
            if (Model.hops.Count > 0)
            {
                selectedHopAddition = 0;
            }
            else
            {
                selectedHopAddition = -1;
            }
            resetSelector();
            AllHops = RecipeHelper.GetAllHops(SessionID);
            HopList = AllHops;
            
            if (Model.hops.Count != 0  && selectedHopAddition != -1)
            {
                hopName = Model.hops[selectedHopAddition].hop.name;
                hopUse = Model.hops[selectedHopAddition].hop.type;
            }
            else
            {
                hopName = "";
                hopUse = "";
            }


            selectedHopID = findHopIDFromSelecteHop();
        }
        
        private int GetHopUseID(string name)
        {
            int i = -1;
            foreach(string s in HopUses)
            {
                if(name == s )
                {
                    return i;
                }
            }
            return i;
        }

        public void Save(bool save)
        {
            RecipeResponse r = RecipeHelper.SaveRecipe(Model, save, SessionID);
            Model.recipeStats = r.recipeStats;
            Model.lastModifiedGuid = r.lastModifiedGuid;
            refreshParent.InvokeAsync("");
        }

        public void ChangeHopAmount(object value, string name)
        {
            float output = -1;
            if(float.TryParse(value.ToString(),out output))
            {
                Model.hops[selectedHopAddition].amount = output;
            }
            Save(false);
        }

        public void ChangeHopAAU(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.hops[selectedHopAddition].hop.aau = Math.Round(output, 2);
            }
            Save(false);
        }

        public void ChangeHopTime(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.hops[selectedHopAddition].time = output;
            }
            Save(false);
        }

        public void ChangeHopUse(object value, string name)
        {
            Model.hops[selectedHopAddition].type = value.ToString();
            hopUse = value.ToString();
            Save(false);
        }

        public void ChangeHop(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            //selectedHopID = value.ToString();

            if(Model.hops.Count == 0)
            {
                hopbase hopw = new hopbase();
                hopAddition ha = new hopAddition();
                Model.hops.Add(ha);
                Model.hops[0].hop = hopw;
                selectedHopAddition = 0;
                hopUse = "";
            }

            if (!(String.IsNullOrEmpty(name) || value == null))
            {
                Model.hops[selectedHopAddition].hop = AllHops.Where(x => x.idString == value).FirstOrDefault();
                Model.hops[selectedHopAddition].hopID = value.ToString();
            }

            if (Model.hops.Count != 0)
            {
                hopName = Model.hops[selectedHopAddition].hop.name;
                hopUse = Model.hops[selectedHopAddition].type;
            }
            else
            {
                hopUse = "";
                hopName = "";
            }

            Save(false);
        }

        public string findHopIDFromSelecteHop()
        {
            resetSelector();
            if (selectedHopAddition != -1 && Model.hops.Count != 0)
            {
                hopbase currentSelection = AllHops.Where(x => x.name == Model.hops[selectedHopAddition].hop.name).FirstOrDefault();
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
            var query = AllHops.AsQueryable();

            if (!string.IsNullOrEmpty(args.Filter))
            {
                query = query.Where(c => c.name.ToLower().Contains(args.Filter.ToLower()));
            }

            HopList = query.ToList();

            InvokeAsync(StateHasChanged);
        }

        public async void AddHop()
        {
            hopAddition ha = RecipeTools.makeEmptyHopAddition();
            selectedHopID = "";
            hopUse = "";

            if (Model.hops.Count > 0)
            {
                Model.hops.Insert(selectedHopAddition + 1, ha);
                selectedHopAddition++;
            }
            else
            {
                Model.hops.Add(ha);
                selectedHopAddition++;
            }
            Save(false);
        }

        public void DeleteHop()
        {
            if (Model.hops.Count == 0)
            { return; }
                Model.hops.RemoveAt(selectedHopAddition);
                if (selectedHopAddition == Model.hops.Count)
                {
                    selectedHopAddition--;
                }
            Save(false);
        }
    }
}
