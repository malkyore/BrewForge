using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class HopEditor : ComponentBase
    {
        public static string operatorvalue = "";
        [Parameter]
        public recipe Model { get; set; }

        IEnumerable<hopbase> AllHops;
        public IEnumerable<hopbase> HopList;

        public string selectedHopID = "";

        public static int selectedHopAddition { get; set; } = 0;

        public async void changeSelectedHop(string id)
        {
            int i = 0;
            int indexOfHop = -1;
            selectedHopID = id;
            foreach(hopAddition ha in Model.hops)
            {
                if(id == ha.additionGuid)
                {
                    indexOfHop = i;
                    break;
                }
                i++;
            }

            if(indexOfHop != -1)
            {
                selectedHopAddition = indexOfHop;
            }
            
        }

        protected override void OnInitialized()
        {
            AllHops = RecipeHelper.GetAllHops();
            HopList = AllHops;
            selectedHopID = findHopIDFromSelecteHop();
        }

        public List<hopbase> loadAllHops()
        {
            return RecipeHelper.GetAllHops();
        }

        public void Change(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            if(Model.hops.Count == 0)
            {
                hopbase hopw = new hopbase();
                hopAddition ha = new hopAddition();
                Model.hops.Add(ha);
                Model.hops[0].hop = hopw;
                selectedHopAddition = 0;
            }
            Model.hops[selectedHopAddition].hop = AllHops.Where(x => x.idString == value).FirstOrDefault();
            Model.hops[selectedHopAddition].hopID = value.ToString();

            //save to api


            StateHasChanged();
        }

        public string findHopIDFromSelecteHop()
        {
            var query = AllHops.AsQueryable();

            query = query.Where(x => x.name == Model.hops[selectedHopAddition].hop.name);

            if(query.Count() != 0)
            {
                return query.FirstOrDefault().idString;
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

        public void AddHop()
        {
            hopAddition ha = new hopAddition();
            hopbase hop = new hopbase();
            ha.hop = hop;
            selectedHopID = "";

            if (Model.hops.Count > 0)
            {
                Model.hops.Insert(selectedHopAddition + 1, ha);
                selectedHopAddition++;
            }
            else
            {
                Model.hops.Add(ha);
            }
        }

        public void DeleteHop()
        {
            if (Model.hops.Count == 0)
            { return; }
            if (selectedHopAddition == (Model.hops.Count - 1) && selectedHopAddition == 0)
            {
                Model.hops.RemoveAt(selectedHopAddition);
            }
            else //otherwise
            {
                Model.hops.RemoveAt(selectedHopAddition);
                if (selectedHopAddition == Model.hops.Count)
                {
                    selectedHopAddition--;
                }
            }
        }
    }
}
