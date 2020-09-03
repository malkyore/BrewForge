using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;
using Microsoft.AspNetCore.ProtectedBrowserStorage;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{

    public class RecipeEditor : ComponentBase
    {
        [Parameter]
        public recipe Model { get; set; }

        [Parameter]
        public string state { get; set; }

        [Inject]
        ProtectedSessionStorage ProtectedSessionStore { get; set; }
        public string SessionID { get; set; } = "";
        public List<style> styleOptions = getStyleOptions();
        public List<style> styleOptionsList = new List<style>();
        public string selectedStyle = "";

        //public async void setSessionID(string sessionState)
        //{
        //    await ProtectedSessionStore.SetAsync("session", sessionState);
        //}

        //public string getSessionID()
        //{
        //    return ProtectedSessionStore.GetAsync<string>("session").Result;
        //}

        public async void setSessionID(string sessionState)
        {
            ProtectedSessionStore.SetAsync("session", sessionState).ConfigureAwait(false);
        }

        public ValueTask<string> getSessionID()
        {
            string session = "";
            return ProtectedSessionStore.GetAsync<string>("session");
        }

        public static List<style> getStyleOptions()
        {
            style a = new style();
            a.name = "test";
            a.description = "no";

            style b = new style();
            a.name = "test2";
            a.description = "no2";

            List<style> styles = new List<style>();

            styles.Add(a);
            styles.Add(b);
            return styles;
        }


        public void refresh()
        {
            StateHasChanged();
        }
        public void ChangeRecipeStyle(object value, string name)
        {
            Model.style = styleOptions.Where(x => x.idString == value).FirstOrDefault();
            selectedStyle = Model.style.idString;
            Save(false);
        }
        
        public void ChangeRecipeName(object value, string name)
        {
            Model.name = value.ToString();
            Save(false);
            
        }

        protected override async void OnInitialized()
        {
            SessionID = state;
            styleOptionsList = styleOptions;
        }
        protected override async void OnAfterRender(bool firstRender)
        {
            getAllStyles();
            selectedStyle = Model.style.idString;
            SessionID = await getSessionID();
            base.OnAfterRender(firstRender);
        }

        public async void getAllStyles()
        {
            styleOptions = RecipeHelper.GetAllStyles(await getSessionID());
        }

        public void ChangeRecipeDescription(object value, string name)
        {
            Model.description = value.ToString();
            Save(false);
        }
        public async void Save(bool save)
        {
            RecipeResponse r = RecipeHelper.SaveRecipe(Model, save, await getSessionID());
            Model.idString = r.idString;
            Model.recipeStats = r.recipeStats;
            Model.lastModifiedGuid = r.lastModifiedGuid;
            StateHasChanged();
        }

        public void LoadData(LoadDataArgs args)
        {
            var query = styleOptions.AsQueryable();

            if (!string.IsNullOrEmpty(args.Filter))
            {
                query = query.Where(c => c.name.ToLower().Contains(args.Filter.ToLower()));
            }

            styleOptionsList = query.ToList();

            StateHasChanged();
        }

    }

    
}
