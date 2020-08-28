using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class FermentableEditor : ComponentBase
    {
        [Parameter]
        public  recipe Model { get; set; }
        public static int selectedFermentableAddition { get; set; } = 0;

        IEnumerable<fermentable> AllFermentables;
        public IEnumerable<fermentable> FermentableList;

        public string fermentableName = "";

        public string selectedFermentableID = "";


        public async void changeSelectedFermentable(string id)
        {
            int i = 0;
            int indexOfFermentable = -1;
            foreach (fermentableAddition fa in Model.fermentables)
            {
                if (id == fa.additionGuid)
                {
                    indexOfFermentable = i;
                    fermentableName = fa.fermentable.name;
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
            AllFermentables = RecipeHelper.GetAllFermentables();
            FermentableList = AllFermentables;
            selectedFermentableID = findFermentableIDFromSelectedFermentable();

            if (Model.fermentables.Count != 0)
            {
                fermentableName = Model.fermentables[selectedFermentableAddition].fermentable.name;
            }
            else
            {
                fermentableName = "";
            }

        }

        public List<hopbase> loadAllHops()
        {
            return RecipeHelper.GetAllHops();
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

            Model.fermentables[selectedFermentableAddition].fermentable = AllFermentables.Where(x => x.idString == value).FirstOrDefault();
            Model.fermentables[selectedFermentableAddition].fermentableID = value.ToString();

            //save to api


            StateHasChanged();
        }

        public string findFermentableIDFromSelectedFermentable()
        {
            var query = AllFermentables.AsQueryable();

            query = query.Where(x => x.name == Model.hops[selectedFermentableAddition].hop.name);

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
            fermentableAddition fa = new fermentableAddition();
            fermentable fermentable = new fermentable();
            fa.fermentable = fermentable;
            selectedFermentableID = "";

            if (Model.fermentables.Count > 0)
            {
                Model.fermentables.Insert(selectedFermentableAddition + 1, fa);
                selectedFermentableAddition++;
            }
            else
            {
                Model.fermentables.Add(fa);
            }
        }

        public void DeleteFermentable()
        {
            if (Model.fermentables.Count == 0)
            { return; }
            //if its the only one
            if (selectedFermentableAddition == (Model.fermentables.Count - 1) && selectedFermentableAddition == 0)
            {
                Model.fermentables.RemoveAt(selectedFermentableAddition);
            }
            else //otherwise
            {
                Model.fermentables.RemoveAt(selectedFermentableAddition);
                if(selectedFermentableAddition == Model.fermentables.Count)
                {
                    selectedFermentableAddition--;
                }
            }
        }

    }
}
