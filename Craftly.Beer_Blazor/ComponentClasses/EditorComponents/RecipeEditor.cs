﻿using Microsoft.AspNetCore.Components;
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

        [Inject]
        ProtectedSessionStorage ProtectedSessionStore { get; set; }

        [CascadingParameter]
        string SessionID { get; set; }
        public List<style> styleOptions = getStyleOptions();
        public List<style> styleOptionsList = new List<style>();
        public string selectedStyle = "";

        public async void setSessionID(string sessionState)
        {
            await ProtectedSessionStore.SetAsync("session", sessionState);
        }

        public string getSessionID()
        {
            return ProtectedSessionStore.GetAsync<string>("session").Result;
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

        protected override void OnInitialized()
        {
            SessionID = getSessionID();
            getAllStyles();
            styleOptionsList = styleOptions;
            selectedStyle = Model.style.idString;
        }

        public void getAllStyles()
        {
            styleOptions = RecipeHelper.GetAllStyles(SessionID);
        }

        public void ChangeRecipeDescription(object value, string name)
        {
            Model.description = value.ToString();
            Save(false);
        }
        public void Save(bool save)
        {
            RecipeResponse r = RecipeHelper.SaveRecipe(Model, save, SessionID);
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
