#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "f953576b859a82dc9bd781b1e18fe5c3dc771a32"
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
            __builder.AddMarkupContent(0, "\r\n\r\n");
            __builder.OpenElement(1, "div");
            __builder.AddAttribute(2, "class", "grid grid-pad widgetItem recipeSelector");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "col-1-2");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "id", "recipeSelector");
            __builder.AddAttribute(9, "class", "module selectorWidget recipeScrollbar");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 25 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
              int index2 = 0;
                foreach (recipe r in recipes)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "                    ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "hopListItem grid");
            __builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 28 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                                                              () => loadRecipe(r.idString)

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(15, "\r\n                        ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "col-1-3");
            __builder.AddMarkupContent(18, "\r\n                            ");
            __builder.AddContent(19, 
#nullable restore
#line 30 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                             r.name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(20, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                        ");
            __builder.OpenElement(22, "div");
            __builder.AddAttribute(23, "class", "col-1-3");
            __builder.AddMarkupContent(24, "\r\n");
#nullable restore
#line 33 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                             if (@r.style != null)
                            {
                                

#line default
#line hidden
#nullable disable
            __builder.AddContent(25, 
#nullable restore
#line 35 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                                 r.style.name

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 35 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                                             
                            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(26, "                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(27, "\r\n                        ");
            __builder.OpenElement(28, "div");
            __builder.AddAttribute(29, "class", "col-1-3");
            __builder.AddMarkupContent(30, "\r\n                            ");
            __builder.AddContent(31, 
#nullable restore
#line 39 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                             r.description

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(32, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(34, "\r\n");
#nullable restore
#line 42 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                    index2++;
                }
            

#line default
#line hidden
#nullable disable
            __builder.AddContent(35, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(36, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n    ");
            __builder.OpenElement(38, "div");
            __builder.AddAttribute(39, "class", "col-1-2 recipeWindow recipeScrollbar");
            __builder.AddMarkupContent(40, "\r\n        ");
            __builder.OpenElement(41, "div");
            __builder.AddAttribute(42, "class", "module grid");
            __builder.AddMarkupContent(43, "\r\n            ");
            __builder.OpenElement(44, "div");
            __builder.AddAttribute(45, "style", "font-size:18px;");
            __builder.AddMarkupContent(46, "\r\n                ");
            __builder.AddContent(47, 
#nullable restore
#line 50 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                 Model.name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(48, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(49, "\r\n            ");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "col-1-3");
            __builder.AddMarkupContent(52, "\r\n                ");
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Routing.NavLink>(53);
            __builder.AddAttribute(54, "href", "Editor");
            __builder.AddAttribute(55, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder2) => {
                __builder2.AddContent(56, "Open Recipe");
            }
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(57, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n        ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "module editorWidget");
            __builder.AddMarkupContent(62, "\r\n            ");
            __builder.OpenElement(63, "div");
            __builder.AddAttribute(64, "class", "statsWidgetSection");
            __builder.AddMarkupContent(65, "\r\n                ");
            __builder.OpenElement(66, "div");
            __builder.AddAttribute(67, "class", "statWidget");
            __builder.AddMarkupContent(68, "\r\n                    ");
            __builder.AddMarkupContent(69, "<div class=\"statTop\">\r\n                        IBU\r\n                    </div>\r\n                    ");
            __builder.OpenElement(70, "div");
            __builder.AddAttribute(71, "class", "statBottom");
            __builder.AddMarkupContent(72, "\r\n                        ");
            __builder.AddContent(73, 
#nullable restore
#line 64 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.ibu, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(74, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(75, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(76, "\r\n                ");
            __builder.OpenElement(77, "div");
            __builder.AddAttribute(78, "class", "statWidget");
            __builder.AddMarkupContent(79, "\r\n                    ");
            __builder.AddMarkupContent(80, "<div class=\"statTop\">\r\n                        ABV\r\n                    </div>\r\n                    ");
            __builder.OpenElement(81, "div");
            __builder.AddAttribute(82, "class", "statBottom");
            __builder.AddMarkupContent(83, "\r\n                        ");
            __builder.AddContent(84, 
#nullable restore
#line 72 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.abv, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(85, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(86, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(87, "\r\n                ");
            __builder.OpenElement(88, "div");
            __builder.AddAttribute(89, "class", "statWidget");
            __builder.AddMarkupContent(90, "\r\n                    ");
            __builder.AddMarkupContent(91, "<div class=\"statTop\">\r\n                        FG\r\n                    </div>\r\n                    ");
            __builder.OpenElement(92, "div");
            __builder.AddAttribute(93, "class", "statBottom");
            __builder.AddMarkupContent(94, "\r\n                        ");
            __builder.AddContent(95, 
#nullable restore
#line 80 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.fg, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(96, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(97, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(98, "\r\n                ");
            __builder.OpenElement(99, "div");
            __builder.AddAttribute(100, "class", "statWidget");
            __builder.AddMarkupContent(101, "\r\n                    ");
            __builder.AddMarkupContent(102, "<div class=\"statTop\">\r\n                        OG\r\n                    </div>\r\n                    ");
            __builder.OpenElement(103, "div");
            __builder.AddAttribute(104, "class", "statBottom");
            __builder.AddMarkupContent(105, "\r\n                        ");
            __builder.AddContent(106, 
#nullable restore
#line 88 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.og, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(107, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(108, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(109, "\r\n                ");
            __builder.OpenElement(110, "div");
            __builder.AddAttribute(111, "class", "statWidget");
            __builder.AddMarkupContent(112, "\r\n                    ");
            __builder.AddMarkupContent(113, "<div class=\"statTop\">\r\n                        SRM\r\n                    </div>\r\n                    ");
            __builder.OpenElement(114, "div");
            __builder.AddAttribute(115, "class", "statBottom");
            __builder.AddMarkupContent(116, "\r\n                        ");
            __builder.AddContent(117, 
#nullable restore
#line 96 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                         Math.Round(Model.recipeStats.srm, 2)

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(118, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(119, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(120, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(121, "\r\n            ");
            __builder.OpenElement(122, "div");
            __builder.AddAttribute(123, "style", "font-size:18px;");
            __builder.AddMarkupContent(124, "\r\n                ");
            __builder.AddContent(125, 
#nullable restore
#line 101 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                 Model.style.name

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(126, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(127, "\r\n            ");
            __builder.OpenElement(128, "div");
            __builder.AddAttribute(129, "style", "font-size:14px;");
            __builder.AddMarkupContent(130, "\r\n                ");
            __builder.AddContent(131, 
#nullable restore
#line 104 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\RecipeSelectorWidget.razor"
                 Model.description

#line default
#line hidden
#nullable disable
            );
            __builder.AddMarkupContent(132, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(133, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(134, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(135, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager NavigationManager { get; set; }
    }
}
#pragma warning restore 1591