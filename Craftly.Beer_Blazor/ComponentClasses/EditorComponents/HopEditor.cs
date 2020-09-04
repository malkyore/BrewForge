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
    public class HopEditor : ComponentBase
    {
        public static string operatorvalue = "";
        [Parameter] public recipe Model { get; set; }
        [Parameter] public string SessionID { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        [Parameter] public HopState hopState { get; set; }

        IEnumerable<hopbase> AllHops;
        public IEnumerable<hopbase> HopList;

        public string hopName = "";
        public string hopUse = "";
        //public string selectedHopID = "";

        public List<string> HopUses = new List<string>{ "Boil", "Whirlpool", "Dry Hop" };

        //public int selectedHopAddition { get; set; } = hopState.currentSelectedHopIndex;

        public void resetSelector()
        {
            if (hopState.currentSelectedHopIndex > Model.hops.Count - 1)
            {
                if (Model.hops.Count > 0)
                {
                    hopState.currentSelectedHopIndex = 0;
                }
                else
                {
                    hopState.currentSelectedHopIndex = -1;
                }
            }
        }

        public void changeSelectedHop(string id)
        {
            int i = 0;
            int indexOfHop = -1;
            hopState.currentSelectedHopID = id;
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
                hopState.currentSelectedHopIndex = indexOfHop;
            }
            Save(false);
        }

        protected override void OnInitialized()
        {
            if (Model.hops.Count > 0)
            {
                hopState.currentSelectedHopIndex = 0;
            }
            else
            {
                hopState.currentSelectedHopIndex = -1;
            }
            resetSelector();
            if(!String.IsNullOrEmpty(SessionID))
            {
                AllHops = RecipeHelper.GetAllHops(SessionID);
                HopList = AllHops;
            }
            
            if (Model.hops.Count != 0  && hopState.currentSelectedHopIndex != -1)
            {
                hopName = Model.hops[hopState.currentSelectedHopIndex].hop.name;
                hopUse = Model.hops[hopState.currentSelectedHopIndex].hop.type;
            }
            else
            {
                hopName = "";
                hopUse = "";
            }

            hopState.currentSelectedHopID = findHopIDFromSelecteHop();
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
            Model.idString = r.idString;
            Model.lastModifiedGuid = r.lastModifiedGuid;
            refreshParent.InvokeAsync("");
        }

        public void ChangeHopAmount(object value, string name)
        {
            float output = -1;
            if(float.TryParse(value.ToString(),out output))
            {
                Model.hops[hopState.currentSelectedHopIndex].amount = output;
            }
            Save(false);
        }

        public void ChangeHopAAU(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.hops[hopState.currentSelectedHopIndex].hop.aau = Math.Round(output, 2);
            }
            Save(false);
        }

        public void ChangeHopTime(object value, string name)
        {
            float output = -1;
            if (float.TryParse(value.ToString(), out output))
            {
                Model.hops[hopState.currentSelectedHopIndex].time = output;
            }
            Save(false);
        }

        public void ChangeHopUse(object value, string name)
        {
            Model.hops[hopState.currentSelectedHopIndex].type = value.ToString();
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
                hopState.currentSelectedHopIndex = 0;
                hopUse = "";
            }

            if (!(String.IsNullOrEmpty(name) || value == null))
            {
                Model.hops[hopState.currentSelectedHopIndex].hop = AllHops.Where(x => x.idString == value).FirstOrDefault();
                Model.hops[hopState.currentSelectedHopIndex].hopID = value.ToString();
            }

            if (Model.hops.Count != 0)
            {
                hopName = Model.hops[hopState.currentSelectedHopIndex].hop.name;
                hopUse = Model.hops[hopState.currentSelectedHopIndex].type;
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
            if (hopState.currentSelectedHopIndex != -1 && Model.hops.Count != 0)
            {
                hopbase currentSelection = AllHops.Where(x => x.name == Model.hops[hopState.currentSelectedHopIndex].hop.name).FirstOrDefault();
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
            if(AllHops != null)
            {
                var query = AllHops.AsQueryable();

                if (!string.IsNullOrEmpty(args.Filter))
                {
                    query = query.Where(c => c.name.ToLower().Contains(args.Filter.ToLower()));
                }

                HopList = query.ToList();

                InvokeAsync(StateHasChanged);
            }
        }

        public async void AddHop()
        {
            hopAddition ha = RecipeTools.makeEmptyHopAddition();
            hopState.currentSelectedHopID = "";
            hopUse = "";

            if (Model.hops.Count > 0)
            {
                Model.hops.Insert(hopState.currentSelectedHopIndex + 1, ha);
                hopState.currentSelectedHopIndex++;
            }
            else
            {
                Model.hops.Add(ha);
                hopState.currentSelectedHopIndex = 0;
                //hopState.currentSelectedHopIndex++;
            }
            Save(false);
        }

        public void DeleteHop()
        {
            if (Model.hops.Count == 0)
            { return; }
                Model.hops.RemoveAt(hopState.currentSelectedHopIndex);
                if (hopState.currentSelectedHopIndex == Model.hops.Count)
                {
                    hopState.currentSelectedHopIndex--;
                }
            Save(false);
        }
    }
}
