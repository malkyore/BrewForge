using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class YeastEditor : ComponentBase
    {
        [Parameter]
        public  recipe Model { get; set; }
        public static int selectedYeastAddition { get; set; } = 0;

        IEnumerable<yeast> AllYeasts;
        public IEnumerable<yeast> YeastList;

        public string selectedHopID = "";

        public async void changeSelectedYeast(string id)
        {
            int i = 0;
            int indexOfYeast = -1;
            foreach (yeastAddition ya in Model.yeasts)
            {
                if (id == ya.additionGuid)
                {
                    indexOfYeast = i;
                    break;
                }
                i++;
            }

            if (indexOfYeast != -1)
            {
                selectedYeastAddition = indexOfYeast;
            }

        }

        protected override void OnInitialized()
        {
            AllYeasts = RecipeHelper.GetAllYeasts();
            YeastList = AllYeasts;
            selectedHopID = findHopIDFromSelecteHop();
        }

        public List<hopbase> loadAllHops()
        {
            return RecipeHelper.GetAllHops();
        }

        public void Change(object value, string name)
        {
            var str = value is IEnumerable<object> ? string.Join(", ", (IEnumerable<object>)value) : value;

            Model.yeasts[selectedYeastAddition].yeast = AllYeasts.Where(x => x.idString == value).FirstOrDefault();

            //save to api


            StateHasChanged();
        }

        public string findHopIDFromSelecteHop()
        {
            var query = AllYeasts.AsQueryable();

            query = query.Where(x => x.name == Model.yeasts[selectedYeastAddition].yeast.name);

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
            yeastAddition ya = new yeastAddition();
            yeast yeast = new yeast();
            ya.yeast = yeast;
            selectedHopID = "";

            if (Model.yeasts.Count > 0)
            {
                Model.yeasts.Insert(selectedYeastAddition + 1, ya);
                selectedYeastAddition++;
            }
            else
            {
                Model.yeasts.Add(ya);
            }
        }

        public void DeleteYeast()
        {
            if (Model.yeasts.Count == 0)
            { return; }
            //if its the only one
            if (selectedYeastAddition == (Model.adjuncts.Count - 1) && selectedYeastAddition == 0)
            {
                yeast yeast = new yeast();
                //Model.yeasts[0] = new yeastAddition();
                //Model.yeasts[0].yeast = yeast;
                Model.adjuncts.RemoveAt(selectedYeastAddition);
            }
            else //otherwise
            {
                Model.adjuncts.RemoveAt(selectedYeastAddition);
                if (selectedYeastAddition == Model.yeasts.Count)
                {
                    selectedYeastAddition--;
                }
            }
        }

    }
}
