using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;
using Beernet_Lib.Tools;
using Craftly.Beer_Blazor.ComponentClasses;
using Beernet_Lib.Models;
using Microsoft.AspNetCore.ProtectedBrowserStorage;
using Craftly.Beer_Blazor.ComponentClasses.ComponentStateClasses;
using Microsoft.AspNetCore.WebUtilities;
using System.Web;

namespace Craftly.Beer_Blazor.ComponentClasses
{
    public class RendererComponent : ComponentBase
    {
        [Inject]
        ProtectedSessionStorage ProtectedSessionStore { get; set; }
        [Inject]
        NavigationManager NavManager { get; set; }
        public string state;

        public string selectedRecipeID;

        public string Username;

        public string selectedVerb;
        public EditorState es { get; set; }

        public recipe Model = RecipeHelper.initializeBlankRecipe();
        public List<recipe> recipes = new List<recipe>();

        protected override async Task OnInitializedAsync()
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            Microsoft.Extensions.Primitives.StringValues firstout = "";
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("RID", out firstout))
            {
                selectedRecipeID = firstout;
            }
            es = generateNewEditorState();
        }

        public async void tryToFindExistingSessionState()
        {
            string sesh = await getSessionID();
            if(!string.IsNullOrEmpty(sesh))
            {
                state = sesh;
                refresh();
            }
        }

        protected override async void OnAfterRender(bool firstRender)
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            state = await getSessionID();
            if (firstRender)
            {
                refresh();
            }

            Microsoft.Extensions.Primitives.StringValues firstout = "";
            bool RIDExists = QueryHelpers.ParseQuery(uri.Query).TryGetValue("RID", out firstout);
            if(RIDExists && selectedRecipeID != firstout)
            {
                NavManager.NavigateTo(URITools.updateQueryParameter(uri, "RID", selectedRecipeID));
                refresh();
            }
        }
        public void setRecipeIDQueryString(string recipeID)
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            Microsoft.Extensions.Primitives.StringValues firstout = "";
            if(QueryHelpers.ParseQuery(uri.Query).TryGetValue("RID", out firstout))
            {
                NavManager.NavigateTo(URITools.updateQueryParameter(uri, "RID", recipeID));
            }
            else
            {
                NavManager.NavigateTo(URITools.addQueryParameter(uri,"RID", recipeID));
            }
        }

        public void setUsername(string username)
        {
            Username = username;
        }

        public void changeVerb(string Verb)
        {
            selectedVerb = Verb;
        }

        public void setVerbQueryString(string verb)
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            Microsoft.Extensions.Primitives.StringValues firstout = "";
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("Verb", out firstout))
            {
                NavManager.NavigateTo(URITools.updateQueryParameter(uri, "Verb", verb));
            }
            else
            {
                NavManager.NavigateTo(URITools.addQueryParameter(uri, "Verb", verb));
            }
        }

        public string removeQueryParameter(Uri uri, string parameter)
        {
            var q = HttpUtility.ParseQueryString(uri.Query);
            q.Remove(parameter);
            string pagePathWithoutQueryString = uri.GetLeftPart(UriPartial.Path);

            var a = q.Count > 0
                ? String.Format("{0}?{1}", pagePathWithoutQueryString, q)
                : pagePathWithoutQueryString;
            return a;
        }

        public string updateQueryParameter(Uri uri, string parameter, string newValue)
        {
            string removedRID = removeQueryParameter(uri, parameter);
            return QueryHelpers.AddQueryString(removedRID, new Dictionary<string, string> { { parameter, newValue } });
        }

        public async void refresh()
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            Microsoft.Extensions.Primitives.StringValues firstout = "";
            if (QueryHelpers.ParseQuery(uri.Query).TryGetValue("RID", out firstout))
            {
                selectedRecipeID = firstout;
                if(Model.idString != selectedRecipeID)
                {
                    Model = RecipeHelper.GetRecipeDetails(selectedRecipeID, state);
                }
            }
            state = await getSessionID();
            if (RecipeHelper.isLoggedIn(state))
            {
                recipes = await RecipeHelper.GetRecipes(state);
            }
            StateHasChanged();
        }

        public async void refreshToHome()
        {
            var uri = NavManager.ToAbsoluteUri(NavManager.Uri);
            selectedRecipeID = "";
            NavManager.NavigateTo(URITools.removeQueryParameter(uri, "RID"));
            //refresh();
            //StateHasChanged();
        }

        public async void refreshAndLogout()
        {
            //state = await getSessionID();
            RecipeHelper.Logout(state);
            state = null;
            selectedRecipeID = "";
            //setRecipeIDQueryString("");
            await ProtectedSessionStore.DeleteAsync("session");
            Model = null;
            StateHasChanged();
        }

        public async void refreshRecipe(string selectedRecipe)
        {
            //state = await getSessionID();
            selectedRecipeID = selectedRecipe;
            setRecipeIDQueryString(selectedRecipe);
            Model = RecipeHelper.GetRecipeDetails(selectedRecipe, state);
            StateHasChanged();
        }

        public async void openNewRecipe()
        {
            selectedRecipeID = "-1";
            es = generateNewEditorState();
            Model = RecipeHelper.initializeBlankRecipe();
            refresh();
        }

        async void saveSessionState(string session)
        {
            await ProtectedSessionStore.SetAsync("session", session);
        }

        ValueTask<string> getSessionID()
        {
            string session = "";
            var sesh = ProtectedSessionStore.GetAsync<string>("session");
            if (!sesh.IsFaulted)
            {
                return sesh;
            }
            else
            {
                return new ValueTask<string>(session);
            }
        }

        EditorState generateNewEditorState()
        {
            EditorState e = new EditorState();
            HopState h = new HopState();
            FermentableState f = new FermentableState();
            YeastState y = new YeastState();
            AdjunctState a = new AdjunctState();

            h.currentSelectedHopID = "";
            h.currentSelectedHopIndex = 0;

            f.currentSelectedFermentableID = "";
            f.currentSelectedFermentableIndex = 0;

            y.currentSelectedYeastID = "";
            y.currentSelectedYeastIndex = 0;

            a.currentSelectedAdjunctID = "";
            a.currentSelectedAdjunctIndex = 0;

            e.hopstate = h;
            e.fermentableState = f;
            e.yeastState = y;
            e.adjunctState = a;

            return e;
        }

        //async void getSessionState()
        //{
        //    string session = null;
        //    try
        //    {
        //        state = await ProtectedSessionStore.GetAsync<string>("session");
        //        if(state != null)
        //        {
        //            isLoggedIn = true;
        //        }
        //        else
        //        {
        //            state = "";
        //            isLoggedIn = false;
        //        }
        //    }
        //    catch(Exception e)
        //    {

        //    }
        //}
        //}
    }
}
