#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\Index.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "353706e289276b816d7a765e20f64fcb3a2559ed"
// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Craftly.Beer_Blazor.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 1 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Craftly.Beer_Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Craftly.Beer_Blazor.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Radzen;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\Index.razor"
using Craftly.Beer_Blazor.ComponentClasses;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\Index.razor"
using Beernet_Lib.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\Index.razor"
using Microsoft.AspNetCore.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/")]
    public partial class Index : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 45 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\Index.razor"
 
    public string state;

    public string selectedRecipeID;

    public recipe Model = RecipeHelper.initializeBlankRecipe();
    public List<recipe> recipes = new List<recipe>();

    protected override async Task OnInitializedAsync()
    {

    }

    protected override async void OnAfterRender(bool firstRender)
    {
        state = await getSessionID();
        //var session = state;
        //if (session != null)
        //{
        //    isLoggedIn = true;
        //    //recipes = await RecipeHelper.GetRecipes(session);
        //}
        if(firstRender)
        {
            refresh();
        }
    }

    public async void refresh()
    {
        state = await getSessionID();
        if (RecipeHelper.isLoggedIn(state))
        {
            recipes = await RecipeHelper.GetRecipes(state);
        }
        StateHasChanged();
    }

    public async void refreshToHome()
    {
        selectedRecipeID = "";
        refresh();
    }

    public async void refreshAndLogout()
    {
        //state = await getSessionID();
        RecipeHelper.Logout(state);
        state = null;
        selectedRecipeID = "";
        ProtectedSessionStore.DeleteAsync("session");
        StateHasChanged();
    }

    public async void refreshRecipe(string selectedRecipe)
    {
        //state = await getSessionID();
        selectedRecipeID = selectedRecipe;
        Model = RecipeHelper.GetRecipeDetails(selectedRecipe, state);
        StateHasChanged();
    }

    public async void openNewRecipe()
    {
        selectedRecipeID = "-1";
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
        return ProtectedSessionStore.GetAsync<string>("session");
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

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedSessionStorage ProtectedSessionStore { get; set; }
    }
}
#pragma warning restore 1591
