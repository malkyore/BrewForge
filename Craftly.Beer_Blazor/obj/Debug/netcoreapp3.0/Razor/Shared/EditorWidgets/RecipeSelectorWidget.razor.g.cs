#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1b6da76f709c5b6c68f01f68d25b4fd1357fae7e"
// <auto-generated/>
#pragma warning disable 1591
namespace Craftly.Beer_Blazor.Shared.EditorWidgets
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
#line 1 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
using Beernet_Lib.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
using Craftly.Beer_Blazor.ComponentClasses.EditorComponents;

#line default
#line hidden
#nullable disable
    public class RecipeSelectorWidget : RecipeSelector
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
#nullable restore
#line 6 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
   if (Model == null)
    {
        Model = new recipe();
        Model.recipeStats = new RecipeStatistics();
        Model.recipeStats.abv = 0;
        Model.recipeStats.fg = 0;
        Model.recipeStats.og = 0;
        Model.recipeStats.srm = 0;
    }
    if (String.IsNullOrEmpty(selectedRecipeIndex))
    {
        selectedRecipeIndex = "00000";
    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(0, "\r\n");
#nullable restore
#line 21 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
  
    void ClickNewRecipe(object args, string text)
    {
        NewRecipe();
        NavManager.NavigateTo("Editor");
    }

    void ClickOpenRecipe(object args, string text)
    {
        NavManager.NavigateTo("Editor");
    }

#line default
#line hidden
#nullable disable
            __builder.AddMarkupContent(1, "\r\n\r\n");
            __builder.OpenElement(2, "div");
            __builder.AddAttribute(3, "class", "grid grid-pad widgetItem recipeSelector");
            __builder.AddMarkupContent(4, "\r\n    ");
            __builder.OpenElement(5, "div");
            __builder.AddAttribute(6, "class", "col-1-2");
            __builder.AddMarkupContent(7, "\r\n        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(8);
            __builder.AddAttribute(9, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                               (args) => ClickNewRecipe(args, "Button with text")

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(10, "Text", "New Recipe");
            __builder.AddAttribute(11, "Style", "margin-bottom: 20px; width: 300px;");
            __builder.CloseComponent();
            __builder.AddMarkupContent(12, "\r\n        ");
            __builder.OpenElement(13, "div");
            __builder.AddAttribute(14, "id", "recipeSelector");
            __builder.AddAttribute(15, "class", "module selectorWidget recipeScrollbar");
            __builder.AddMarkupContent(16, "\r\n");
#nullable restore
#line 39 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
              int index2 = 0;
                foreach (recipe r in recipes)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(17, "                    ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "hopListItem grid");
            __builder.AddAttribute(20, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 42 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                                                              () => loadRecipe(r.idString)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(21, "\r\n                        ");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "col-1-3");
            __builder.AddMarkupContent(24, "\r\n                            ");
            __builder.AddContent(25, 
#nullable restore
#line 44 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                             r.name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(26, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                        ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "col-1-3");
            __builder.AddMarkupContent(30, "\r\n");
#nullable restore
#line 47 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                             if (@r.style != null)
                            {
                                

#line default
#line hidden
#nullable disable
            __builder.AddContent(31, 
#nullable restore
#line 49 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                                 r.style.name

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 49 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                                             
                            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(32, "                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                        ");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "col-1-3");
            __builder.AddMarkupContent(36, "\r\n                            ");
            __builder.AddContent(37, 
#nullable restore
#line 53 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                             r.description

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(38, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n");
#nullable restore
#line 56 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                    index2++;
                }
            

#line default
#line hidden
#nullable disable
            __builder.AddContent(41, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(42, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n    ");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "class", "col-1-2 recipeWindow recipeScrollbar");
            __builder.AddMarkupContent(46, "\r\n        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(47);
            __builder.AddAttribute(48, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 62 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                               (args) => ClickOpenRecipe(args, "Button with text")

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(49, "Text", "Open Recipe");
            __builder.AddAttribute(50, "Style", "margin-bottom: 20px; width: 300px;");
            __builder.CloseComponent();
            __builder.AddMarkupContent(51, "\r\n        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenButton>(52);
            __builder.AddAttribute(53, "Click", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 63 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                               (args) => ClickDeleteRecipe(args, "Button with text")

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(54, "Text", "Delete Recipe");
            __builder.AddAttribute(55, "Style", "margin-bottom: 20px; width: 300px;");
            __builder.CloseComponent();
            __builder.AddMarkupContent(56, "\r\n        ");
            __builder.OpenElement(57, "div");
            __builder.AddAttribute(58, "class", "module grid");
            __builder.AddMarkupContent(59, "\r\n            ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "style", "font-size:18px;");
            __builder.AddMarkupContent(62, "\r\n                ");
            __builder.AddContent(63, 
#nullable restore
#line 66 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                 Model.name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(64, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(65, "\r\n            ");
            __builder.AddMarkupContent(66, "<div class=\"col-1-3\">\r\n\r\n            </div>\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n        ");
            __builder.OpenElement(68, "div");
            __builder.AddAttribute(69, "class", "module editorWidget");
            __builder.AddMarkupContent(70, "\r\n            ");
            __builder.OpenElement(71, "div");
            __builder.AddAttribute(72, "class", "statsWidgetSection");
            __builder.AddMarkupContent(73, "\r\n                ");
            __builder.OpenElement(74, "div");
            __builder.AddAttribute(75, "class", "statWidget");
            __builder.AddMarkupContent(76, "\r\n                    ");
            __builder.AddMarkupContent(77, "<div class=\"statTop\">\r\n                        IBU\r\n                    </div>\r\n                    ");
            __builder.OpenElement(78, "div");
            __builder.AddAttribute(79, "class", "statBottom");
            __builder.AddMarkupContent(80, "\r\n                        ");
            __builder.AddContent(81, 
#nullable restore
#line 79 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.ibu, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(82, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(83, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(84, "\r\n                ");
            __builder.OpenElement(85, "div");
            __builder.AddAttribute(86, "class", "statWidget");
            __builder.AddMarkupContent(87, "\r\n                    ");
            __builder.AddMarkupContent(88, "<div class=\"statTop\">\r\n                        ABV\r\n                    </div>\r\n                    ");
            __builder.OpenElement(89, "div");
            __builder.AddAttribute(90, "class", "statBottom");
            __builder.AddMarkupContent(91, "\r\n                        ");
            __builder.AddContent(92, 
#nullable restore
#line 87 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.abv, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(93, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(95, "\r\n                ");
            __builder.OpenElement(96, "div");
            __builder.AddAttribute(97, "class", "statWidget");
            __builder.AddMarkupContent(98, "\r\n                    ");
            __builder.AddMarkupContent(99, "<div class=\"statTop\">\r\n                        FG\r\n                    </div>\r\n                    ");
            __builder.OpenElement(100, "div");
            __builder.AddAttribute(101, "class", "statBottom");
            __builder.AddMarkupContent(102, "\r\n                        ");
            __builder.AddContent(103, 
#nullable restore
#line 95 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.fg, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(104, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(105, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n                ");
            __builder.OpenElement(107, "div");
            __builder.AddAttribute(108, "class", "statWidget");
            __builder.AddMarkupContent(109, "\r\n                    ");
            __builder.AddMarkupContent(110, "<div class=\"statTop\">\r\n                        OG\r\n                    </div>\r\n                    ");
            __builder.OpenElement(111, "div");
            __builder.AddAttribute(112, "class", "statBottom");
            __builder.AddMarkupContent(113, "\r\n                        ");
            __builder.AddContent(114, 
#nullable restore
#line 103 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.og, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(115, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(116, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(117, "\r\n                ");
            __builder.OpenElement(118, "div");
            __builder.AddAttribute(119, "class", "statWidget");
            __builder.AddMarkupContent(120, "\r\n                    ");
            __builder.AddMarkupContent(121, "<div class=\"statTop\">\r\n                        SRM\r\n                    </div>\r\n                    ");
            __builder.OpenElement(122, "div");
            __builder.AddAttribute(123, "class", "statBottom");
            __builder.AddMarkupContent(124, "\r\n                        ");
            __builder.AddContent(125, 
#nullable restore
#line 111 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.srm, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(126, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(127, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(128, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(129, "\r\n            ");
            __builder.OpenElement(130, "div");
            __builder.AddAttribute(131, "style", "font-size:18px;");
            __builder.AddMarkupContent(132, "\r\n                ");
            __builder.AddContent(133, 
#nullable restore
#line 116 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                 Model.style.name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(134, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(135, "\r\n            ");
            __builder.OpenElement(136, "div");
            __builder.AddAttribute(137, "style", "font-size:14px;");
            __builder.AddMarkupContent(138, "\r\n                ");
            __builder.AddContent(139, 
#nullable restore
#line 119 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                 Model.description

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(140, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(142, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(143, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavManager { get; set; }
    }
}
#pragma warning restore 1591
