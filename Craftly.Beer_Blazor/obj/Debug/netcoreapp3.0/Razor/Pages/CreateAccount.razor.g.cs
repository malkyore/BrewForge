#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "52809df9767863503105097429ceeff58992189d"
// <auto-generated/>
#pragma warning disable 1591
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
#line 2 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
using Craftly.Beer_Blazor.ComponentClasses;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
using Beernet_Lib.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
using Microsoft.AspNetCore.ProtectedBrowserStorage;

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/CreateAccount")]
    public partial class CreateAccount : Craftly.Beer_Blazor.ComponentClasses.CreateAccountComponent
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.AddMarkupContent(0, "<div id=\"header\">\r\n    <br>\r\n    <br>\r\n</div>\r\n");
            __builder.AddMarkupContent(1, "<div id=\"toolbar\" class=\"btn-group\">\r\n\r\n</div>\r\n");
            __builder.OpenElement(2, "div");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.AddMarkupContent(4, "<h1 style=\"text-align:center; vertical-align:central;margin: auto;\">Craftly.Beer</h1>\r\n    <br>\r\n    <br>\r\n    ");
            __builder.AddMarkupContent(5, "<div class=\"module\" style=\"width:200px; text-align:center; vertical-align:central;margin: auto;\">\r\n        <img src=\"/images/hop.png\" style=\"width: 200px; height:200px; padding-right:10px;margin-left:-10px\">\r\n        \r\n    </div>\r\n    <br>\r\n    ");
            __builder.OpenElement(6, "div");
            __builder.AddAttribute(7, "class", "module");
            __builder.AddAttribute(8, "style", "width:350px; text-align:center; vertical-align:central;margin: auto;");
            __builder.AddMarkupContent(9, "\r\n        ");
            __builder.AddMarkupContent(10, "<div>\r\n            <h4>Create Account</h4>\r\n        </div>\r\n        ");
            __builder.OpenElement(11, "div");
            __builder.AddMarkupContent(12, "\r\n            ");
            __builder.AddMarkupContent(13, "<label>Username:</label> <br>\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(14);
            __builder.AddAttribute(15, "Style", "margin-bottom: 20px; width:250px;");
            __builder.AddAttribute(16, "Change", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, 
#nullable restore
#line 31 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
                                                                               args => ChangeUsername(args)

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(17, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(18, "\r\n        ");
            __builder.OpenElement(19, "div");
            __builder.AddMarkupContent(20, "\r\n            ");
            __builder.AddMarkupContent(21, "<label>Email:</label> <br>\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(22);
            __builder.AddAttribute(23, "Style", "margin-bottom: 20px; width:250px;");
            __builder.AddAttribute(24, "Change", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, 
#nullable restore
#line 35 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
                                                                               args => ChangeEmail(args)

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(25, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(26, "\r\n        ");
            __builder.OpenElement(27, "div");
            __builder.AddMarkupContent(28, "\r\n            ");
            __builder.AddMarkupContent(29, "<label>Password:</label><br>\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenPassword>(30);
            __builder.AddAttribute(31, "Placeholder", "Enter password...");
            __builder.AddAttribute(32, "Change", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, 
#nullable restore
#line 39 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
                                                                      args => ChangePassword(args)

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(33, "Click", "sdd");
            __builder.AddAttribute(34, "Style", "margin-bottom: 20px; width:250px;");
            __builder.CloseComponent();
            __builder.AddMarkupContent(35, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n        ");
            __builder.OpenElement(37, "div");
            __builder.AddMarkupContent(38, "\r\n            ");
            __builder.AddMarkupContent(39, "<label>Confirm Password:</label><br>\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenPassword>(40);
            __builder.AddAttribute(41, "Placeholder", "Enter password...");
            __builder.AddAttribute(42, "Change", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.String>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.String>(this, 
#nullable restore
#line 43 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
                                                                      args => ChangeConfirmPassword(args)

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(43, "Click", "sdd");
            __builder.AddAttribute(44, "Style", "margin-bottom: 20px; width:250px;");
            __builder.CloseComponent();
            __builder.AddMarkupContent(45, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(46, "\r\n        ");
            __builder.OpenElement(47, "div");
            __builder.AddMarkupContent(48, "\r\n            <br>\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(49);
            __builder.AddAttribute(50, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 47 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
                                   (args) => CreateAccount()

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(51, "Text", "Create Account");
            __builder.AddAttribute(52, "Style", "margin-bottom: 20px; width: 250px");
            __builder.CloseComponent();
            __builder.AddMarkupContent(53, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n\r\n        ");
            __builder.OpenElement(55, "div");
            __builder.AddMarkupContent(56, "\r\n            <br>\r\n            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(57);
            __builder.AddAttribute(58, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 52 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
                                   (args) => backToLogin()

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(59, "Text", "Back to Login");
            __builder.AddAttribute(60, "Style", "margin-bottom: 20px; width: 250px");
            __builder.CloseComponent();
            __builder.AddMarkupContent(61, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(62, "\r\n\r\n");
#nullable restore
#line 55 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
         if (isError)
        {

#line default
#line hidden
#nullable disable
            __builder.AddContent(63, "            ");
            __builder.OpenElement(64, "div");
            __builder.AddAttribute(65, "style", "color:red;");
            __builder.AddContent(66, 
#nullable restore
#line 57 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
                                     ErrorMessage

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n");
#nullable restore
#line 58 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Pages\CreateAccount.razor"
        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(68, "    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ProtectedSessionStorage ProtectedSessionStore { get; set; }
    }
}
#pragma warning restore 1591