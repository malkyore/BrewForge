using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class AdjunctEditor : ComponentBase
    {
        [Parameter]
        public  recipe Model { get; set; }
        public static int selectedAdjunctAddition { get; set; } = 0;

        IEnumerable<adjunct> AllAdjuncts;
        public IEnumerable<adjunct> AdjunctList;

        public string adjunctName = "";
        public string selectedAdjunctID = "";

        public async void changeSelectedAdjunct(string id)
        {
            int i = 0;
            int indexOfAdjunct = -1;
            foreach (adjunctAddition aa in Model.adjuncts)
            {
                if (id == aa.additionGuid)
                {
                    indexOfAdjunct = i;
                    adjunctName = aa.adjunct.name;
                    break;
                }
                i++;
            }

            if (indexOfAdjunct != -1)
            {
                selectedAdjunctAddition = indexOfAdjunct;
            }

        }

        protected override void OnInitialized()
        {
            AllAdjuncts = RecipeHelper.GetAllAdjuncts();
            AdjunctList = AllAdjuncts;
            selectedAdjunctID = findAdjunctIDFromSelecteAdjunct();

            if (Model.adjuncts.Count != 0)
            {
                adjunctName = Model.adjuncts[selectedAdjunctAddition].adjunct.name;
            }
            else
            {
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

            //save to api


            StateHasChanged();
        }

        public string findAdjunctIDFromSelecteAdjunct()
        {
            var query = AllAdjuncts.AsQueryable();

            query = query.Where(x => x.name == Model.hops[selectedAdjunctAddition].hop.name);

            if (query.Count() != 0)
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
            var query = AllAdjuncts.AsQueryable();

            if (!string.IsNullOrEmpty(args.Filter))
            {
                query = query.Where(c => c.name.ToLower().Contains(args.Filter.ToLower()));
            }

            AdjunctList = query.ToList();

            InvokeAsync(StateHasChanged);
        }

        public void AddAdjunct()
        {
            adjunctAddition aa = new adjunctAddition();
            adjunct adjunct = new adjunct();
            aa.adjunct = adjunct;
            selectedAdjunctID = "";
            if (Model.adjuncts.Count > 0)
            {
                Model.adjuncts.Insert(selectedAdjunctAddition + 1, aa);
                selectedAdjunctAddition++;
            }
            else
            {
                Model.adjuncts.Add(aa);
            }
        }

        public void DeleteAdjunct()
        {
            if (Model.adjuncts.Count == 0)
            { return; }
                //if its the only one
                if (selectedAdjunctAddition == (Model.adjuncts.Count - 1) && selectedAdjunctAddition == 0)
                {
                    //adjunct adjunct = new adjunct();
                    Model.adjuncts.RemoveAt(selectedAdjunctAddition);
                }
                else //otherwise
                {
                    Model.adjuncts.RemoveAt(selectedAdjunctAddition);
                    if (selectedAdjunctAddition == Model.adjuncts.Count)
                    {
                        selectedAdjunctAddition--;
                    }
                }
        }
    }
}
