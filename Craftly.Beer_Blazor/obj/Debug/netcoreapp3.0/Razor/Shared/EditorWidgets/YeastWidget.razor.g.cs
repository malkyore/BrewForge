#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "aaa9a9a555ebe9dabf235a03f4d030b56a0a39d5"
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
#line 1 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
using Beernet_Lib.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
using Craftly.Beer_Blazor.ComponentClasses.EditorComponents;

#line default
#line hidden
#nullable disable
    public class YeastWidget : YeastEditor
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "yeastWidgetWrapper");
            __builder.AddAttribute(2, "class", "grid grid-pad widgetItem recipeEditorWidget");
            __builder.AddMarkupContent(3, "\r\n            ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "col-1-2");
            __builder.AddMarkupContent(6, "\r\n                ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "id", "yeastListSelector");
            __builder.AddAttribute(9, "class", "module selectorWidget");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 8 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                      int index2 = 0;
                        foreach (yeastAddition y in Model.yeasts)
                        {
                            string name = "y" + index2;

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "                            ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "id", 
#nullable restore
#line 12 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                     name

#line default
#line hidden
#nullable disable
            );
            __builder.AddAttribute(14, "class", "hopListItem" + " grid" + " " + (
#nullable restore
#line 12 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                                    index2 == selectedYeastAddition ? "hopListItemSelected" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(15, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 12 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                                                                                                             (() => changeSelectedYeast(y.additionGuid))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(16, "\r\n                                ");
            __builder.OpenElement(17, "div");
            __builder.AddAttribute(18, "class", "col-1-3");
            __builder.AddMarkupContent(19, "\r\n                                    ");
            __builder.OpenElement(20, "div");
            __builder.AddContent(21, 
#nullable restore
#line 14 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                          y.yeast.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(22, "\r\n                                    ");
            __builder.AddMarkupContent(23, "<div class=\"ingredientUnit\">name</div>\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(24, "\r\n                                ");
            __builder.OpenElement(25, "div");
            __builder.AddAttribute(26, "class", "col-1-3");
            __builder.AddMarkupContent(27, "\r\n                                    ");
            __builder.OpenElement(28, "div");
            __builder.AddContent(29, 
#nullable restore
#line 18 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                          y.yeast.lab

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(30, "\r\n                                    ");
            __builder.AddMarkupContent(31, "<div class=\"ingredientUnit\">lab</div>\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(32, "\r\n                                ");
            __builder.OpenElement(33, "div");
            __builder.AddAttribute(34, "class", "col-1-3");
            __builder.AddMarkupContent(35, "\r\n                                    ");
            __builder.OpenElement(36, "div");
            __builder.AddContent(37, 
#nullable restore
#line 22 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                          y.yeast.attenuation

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(38, "\r\n                                    ");
            __builder.AddMarkupContent(39, "<div class=\"ingredientUnit\">attenuation</div>\r\n                                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n");
#nullable restore
#line 26 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                            index2++;
                        }
                    

#line default
#line hidden
#nullable disable
            __builder.AddContent(42, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(43, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(44, "\r\n            ");
            __builder.OpenElement(45, "div");
            __builder.AddAttribute(46, "class", "col-1-2");
            __builder.AddMarkupContent(47, "\r\n                ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "module grid");
            __builder.AddMarkupContent(50, "\r\n                    ");
            __builder.OpenElement(51, "div");
            __builder.AddAttribute(52, "class", "col-1-2");
            __builder.AddMarkupContent(53, "\r\n                        ");
            __builder.OpenElement(54, "button");
            __builder.AddAttribute(55, "type", "button");
            __builder.AddAttribute(56, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 34 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                        (() => AddYeast())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(57, "Add Yeast");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(59, "\r\n                    ");
            __builder.OpenElement(60, "div");
            __builder.AddAttribute(61, "class", "col-1-2");
            __builder.AddMarkupContent(62, "\r\n                        ");
            __builder.OpenElement(63, "button");
            __builder.AddAttribute(64, "type", "button");
            __builder.AddAttribute(65, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                        (() => DeleteYeast())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(66, "Delete Yeast");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(69, "\r\n                ");
            __builder.OpenElement(70, "div");
            __builder.AddAttribute(71, "class", "module editorWidget");
            __builder.AddMarkupContent(72, "\r\n                    ");
            __builder.AddMarkupContent(73, "<h4 style=\"padding-top:0;\">Edit Yeast</h4>\r\n                    ");
            __builder.OpenElement(74, "div");
            __builder.AddAttribute(75, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(76, "\r\n                        ");
            __builder.AddMarkupContent(77, "<div class=\"col-1-4 editorLabel\">\r\n                            <label>Yeast: </label>\r\n                        </div>\r\n                        ");
            __builder.OpenElement(78, "div");
            __builder.AddAttribute(79, "class", "col-3-4");
            __builder.AddMarkupContent(80, "\r\n                            ");
            __builder.OpenComponent<Radzen.Blazor.RadzenDropDown<string>>(81);
            __builder.AddAttribute(82, "AllowClear", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 47 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                        true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(83, "LoadData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.LoadDataArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.LoadDataArgs>(this, 
#nullable restore
#line 48 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                       LoadData

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(84, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 48 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                                                 true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(85, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.IEnumerable>(
#nullable restore
#line 49 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                   YeastList

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(86, "TextProperty", "name");
            __builder.AddAttribute(87, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 49 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                                                          selectedYeastAddition

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(88, "Placeholder", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 49 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                                                                                               yeastName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(89, "ValueProperty", "idString");
            __builder.AddAttribute(90, "Style", "width: 100%;");
            __builder.AddAttribute(91, "Change", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, 
#nullable restore
#line 50 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                      args => Change(args, "DropDown with custom filtering")

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(92, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(94, "\r\n                    ");
            __builder.OpenElement(95, "div");
            __builder.AddAttribute(96, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(97, "\r\n                        ");
            __builder.AddMarkupContent(98, "<div class=\"col-1-4 editorLabel\">\r\n                            <label>Lab: </label>\r\n                        </div>\r\n                        ");
            __builder.OpenElement(99, "div");
            __builder.AddAttribute(100, "class", "col-3-4");
            __builder.AddMarkupContent(101, "\r\n                            ");
            __builder.OpenElement(102, "label");
            __builder.AddMarkupContent(103, "\r\n");
#nullable restore
#line 59 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                 if (selectedYeastAddition != -1 && Model.yeasts.Count != 0)
                                {
                                    

#line default
#line hidden
#nullable disable
            __builder.AddContent(104, 
#nullable restore
#line 61 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                     Model.yeasts[selectedYeastAddition].yeast.lab

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 61 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                                                  
                                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(105, "                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(107, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(108, "\r\n                    ");
            __builder.OpenElement(109, "div");
            __builder.AddAttribute(110, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(111, "\r\n                        ");
            __builder.AddMarkupContent(112, "<div class=\"col-1-4 editorLabel\">\r\n                            <label>Attenuation:</label>\r\n                        </div>\r\n                        ");
            __builder.OpenElement(113, "div");
            __builder.AddAttribute(114, "class", "col-3-4");
            __builder.AddMarkupContent(115, "\r\n                            ");
            __builder.OpenElement(116, "label");
            __builder.AddMarkupContent(117, "\r\n");
#nullable restore
#line 72 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                 if (selectedYeastAddition != -1 && Model.yeasts.Count != 0)
                                {
                                    

#line default
#line hidden
#nullable disable
            __builder.AddContent(118, 
#nullable restore
#line 74 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                     Model.yeasts[selectedYeastAddition].yeast.attenuation

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 74 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\YeastWidget.razor"
                                                                                          
                                }

#line default
#line hidden
#nullable disable
            __builder.AddContent(119, "                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(120, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(121, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(122, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(123, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(124, "\r\n        ");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
