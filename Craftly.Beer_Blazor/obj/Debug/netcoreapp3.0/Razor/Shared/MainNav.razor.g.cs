#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\MainNav.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "00e9ef0a669fe67d081f17d7ca0fcc5451db9f79"
// <auto-generated/>
#pragma warning disable 1591
namespace Craftly.Beer_Blazor.Shared
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
    public class MainNav : Craftly.Beer_Blazor.ComponentClasses.MainNavComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "nav");
            __builder.AddAttribute(1, "class", "main-menu");
            __builder.AddMarkupContent(2, "\r\n    ");
            __builder.AddMarkupContent(3, "<ul>\r\n        <li>\r\n            <a href>\r\n                <img src=\"/images/hop.png\" style=\"width: 50px; height:50px; padding:4px;\">\r\n                <span class=\"nav-text\" style=\"padding-top:17px;Padding-left:7px;\">\r\n                    <h3>Craftly.Beer</h3>\r\n                </span>\r\n            </a>\r\n\r\n        </li>\r\n        <li>\r\n            <a onclick=\"openNewRecipe(this)\">\r\n                <i class=\"fa fa-plus-circle fa-2x\"></i>\r\n                <span class=\"nav-text\">\r\n                    New Recipe\r\n                </span>\r\n            </a>\r\n        </li>\r\n        <li>\r\n            <a href>\r\n                <i class=\"fa fa-bar-chart-o fa-2x\"></i>\r\n                <span class=\"nav-text\">\r\n                    Dashboard\r\n                </span>\r\n            </a>\r\n\r\n        </li>\r\n        <li class=\"has-subnav\">\r\n            <a onclick=\"viewRecipes(this)\">\r\n                <i class=\"fa fa-list fa-2x\"></i>\r\n                <span class=\"nav-text\">\r\n                    Recipes\r\n                </span>\r\n            </a>\r\n\r\n        </li>\r\n        <li class=\"has-subnav\">\r\n            <a href>\r\n                <i class=\"fa fa-clipboard fa-2x\"></i>\r\n                <span class=\"nav-text\">\r\n                    Brew Logs\r\n                </span>\r\n            </a>\r\n\r\n        </li>\r\n        <li class=\"has-subnav\">\r\n            <a href=\"#\">\r\n                <i class=\"fa fa-folder-open fa-2x\"></i>\r\n                <span class=\"nav-text\">\r\n                    Account\r\n                </span>\r\n            </a>\r\n\r\n        </li>\r\n        <li>\r\n            <a href>\r\n                <i class=\"fa fa-cogs fa-2x\"></i>\r\n                <span class=\"nav-text\">\r\n                    Admin\r\n                </span>\r\n            </a>\r\n        </li>\r\n    </ul>\r\n\r\n    ");
            __builder.OpenElement(4, "ul");
            __builder.AddAttribute(5, "class", "logout");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "li");
            __builder.AddMarkupContent(8, "\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(9);
            __builder.AddAttribute(10, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 72 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\MainNav.razor"
                                   (args) => ClickLogout()

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(11, "Image", "images/radzen-nuget.png");
            __builder.AddAttribute(12, "ButtonStyle", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Radzen.ButtonStyle>(
#nullable restore
#line 72 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\MainNav.razor"
                                                                                                          ButtonStyle.Light

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(13, "class", "fa fa-power-off fa-2x");
            __builder.CloseComponent();
            __builder.AddMarkupContent(14, "\r\n            ");
            __builder.AddMarkupContent(15, "<a href>\r\n                <i class=\"fa fa-power-off fa-2x\"></i>\r\n                <span class=\"nav-text\">\r\n                    Logout\r\n                </span>\r\n            </a>\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(16, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(17, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
#nullable restore
#line 84 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\MainNav.razor"
 
    bool isLoggedIn = isLoggedIn();
    void ClickLogout()
    {
        logout();
        refreshParent.InvokeAsync("");;
        NavManager.NavigateTo("/");
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
