#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "d2c1b0d6be0950e673dd795f9323c3e940fb2b95"
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
#line 11 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\_Imports.razor"
using Radzen.Blazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 1 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
using Beernet_Lib.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
using Craftly.Beer_Blazor.ComponentClasses.EditorComponents;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
using Radzen;

#line default
#line hidden
#nullable disable
    public class HopWidget : HopEditor
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "hopWidgetWrapper");
            __builder.AddAttribute(2, "class", "grid grid-pad widgetItem recipeEditorWidget");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "col-1-2");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "id", "hopListSelector");
            __builder.AddAttribute(9, "class", "module selectorWidget");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 10 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
             if (Model.hops == null)
            {

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "                ");
            __builder.AddMarkupContent(12, "<p> loading...</p>\r\n");
#nullable restore
#line 13 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
            }
            else
            {
                int i = 0;
                foreach (hopAddition ha in Model.hops)
                {

#line default
#line hidden
#nullable disable
            __builder.AddContent(13, "                    ");
            __builder.OpenElement(14, "div");
            __builder.AddAttribute(15, "class", "hopListItem grid");
            __builder.AddAttribute(16, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 19 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                            (() => changeSelectedHop(ha.additionGuid))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(17, "\r\n                        ");
            __builder.OpenElement(18, "div");
            __builder.AddAttribute(19, "class", "col-1-4");
            __builder.AddMarkupContent(20, "\r\n                            ");
            __builder.OpenElement(21, "div");
            __builder.AddContent(22, 
#nullable restore
#line 21 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                  ha.hop.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                            ");
            __builder.AddMarkupContent(24, "<div class=\"ingredientUnit\">name</div>\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(25, "\r\n                        ");
            __builder.OpenElement(26, "div");
            __builder.AddAttribute(27, "class", "col-1-4 ingredientUnitParent");
            __builder.AddMarkupContent(28, "\r\n                            ");
            __builder.OpenElement(29, "div");
            __builder.AddContent(30, 
#nullable restore
#line 25 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                  ha.hop.aau

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                            ");
            __builder.AddMarkupContent(32, "<div class=\"ingredientUnit\">aau</div>\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(33, "\r\n                        ");
            __builder.OpenElement(34, "div");
            __builder.AddAttribute(35, "class", "col-1-4 ingredientUnitParent");
            __builder.AddMarkupContent(36, "\r\n                            ");
            __builder.OpenElement(37, "div");
            __builder.AddContent(38, 
#nullable restore
#line 29 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                  ha.amount

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                            ");
            __builder.AddMarkupContent(40, "<div class=\"ingredientUnit\">oz</div>\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(41, "\r\n                        ");
            __builder.OpenElement(42, "div");
            __builder.AddAttribute(43, "class", "col-1-4 ingredientUnitParent");
            __builder.AddMarkupContent(44, "\r\n                            ");
            __builder.OpenElement(45, "div");
            __builder.AddContent(46, 
#nullable restore
#line 33 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                  ha.time

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(47, "\r\n                            ");
            __builder.OpenElement(48, "div");
            __builder.AddAttribute(49, "class", "ingredientUnit");
            __builder.AddContent(50, " ");
            __builder.AddContent(51, 
#nullable restore
#line 34 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                           ha.type == "Dry Hop" ? "days" : "min"

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(52, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(53, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(54, "\r\n");
#nullable restore
#line 37 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                    i++;
                }
            }

#line default
#line hidden
#nullable disable
            __builder.AddContent(55, "        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(56, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n    ");
            __builder.OpenElement(58, "div");
            __builder.AddAttribute(59, "class", "col-1-2");
            __builder.AddMarkupContent(60, "\r\n        ");
            __builder.OpenElement(61, "div");
            __builder.AddAttribute(62, "class", "module grid");
            __builder.AddMarkupContent(63, "\r\n            ");
            __builder.OpenElement(64, "div");
            __builder.AddAttribute(65, "class", "col-1-2");
            __builder.AddMarkupContent(66, "\r\n                ");
            __builder.OpenElement(67, "button");
            __builder.AddAttribute(68, "type", "button");
            __builder.AddAttribute(69, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 45 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                (() => AddHop())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(70, "Add Hop");
            __builder.CloseElement();
            __builder.AddMarkupContent(71, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(72, "\r\n            ");
            __builder.OpenElement(73, "div");
            __builder.AddAttribute(74, "class", "col-1-2");
            __builder.AddMarkupContent(75, "\r\n                ");
            __builder.OpenElement(76, "button");
            __builder.AddAttribute(77, "type", "button");
            __builder.AddAttribute(78, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 48 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                (() => DeleteHop())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(79, "Delete Hop");
            __builder.CloseElement();
            __builder.AddMarkupContent(80, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(81, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(82, "\r\n        ");
            __builder.OpenElement(83, "div");
            __builder.AddAttribute(84, "class", "module editorWidget");
            __builder.AddMarkupContent(85, "\r\n            ");
            __builder.AddMarkupContent(86, "<h4 style=\"padding-top:0;\">Edit Hop</h4>\r\n            ");
            __builder.OpenElement(87, "div");
            __builder.AddAttribute(88, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(89, "\r\n                ");
            __builder.AddMarkupContent(90, "<div class=\"col-1-4\">\r\n                    <label>Hop: </label>\r\n                </div>\r\n                ");
            __builder.OpenElement(91, "div");
            __builder.AddAttribute(92, "class", "col-3-4");
            __builder.AddMarkupContent(93, "\r\n                    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenDropDown<string>>(94);
            __builder.AddAttribute(95, "AllowClear", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 58 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(96, "LoadData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.LoadDataArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.LoadDataArgs>(this, 
#nullable restore
#line 59 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                               LoadData

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(97, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 59 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                                         true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(98, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.IEnumerable>(
#nullable restore
#line 60 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                           HopList

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(99, "TextProperty", "name");
            __builder.AddAttribute(100, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 60 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                                                selectedHopID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(101, "Placeholder", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 60 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                                                                                             Model.hops[selectedHopAddition].hop.name

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(102, "ValueProperty", "idString");
            __builder.AddAttribute(103, "Style", "margin-bottom: 30px");
            __builder.AddAttribute(104, "Change", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, 
#nullable restore
#line 61 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                              args => Change(args, "DropDown with custom filtering")

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(105, "\r\n\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(106, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(107, "\r\n            ");
            __builder.OpenElement(108, "div");
            __builder.AddAttribute(109, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(110, "\r\n                ");
            __builder.AddMarkupContent(111, "<div class=\"col-1-4\">\r\n                    <label>AAU: </label>\r\n                </div>\r\n                ");
            __builder.OpenElement(112, "div");
            __builder.AddAttribute(113, "class", "col-3-4");
            __builder.AddMarkupContent(114, "\r\n                    ");
            __builder.OpenElement(115, "label");
            __builder.AddContent(116, 
#nullable restore
#line 70 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                            Model.hops[selectedHopAddition].hop.aau

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(117, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(118, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(119, "\r\n            ");
            __builder.OpenElement(120, "div");
            __builder.AddAttribute(121, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(122, "\r\n                ");
            __builder.AddMarkupContent(123, "<div class=\"col-1-4\">\r\n                    <label>amount</label>\r\n                </div>\r\n                ");
            __builder.OpenElement(124, "div");
            __builder.AddAttribute(125, "class", "col-3-4");
            __builder.AddMarkupContent(126, "\r\n                    ");
            __builder.OpenElement(127, "input");
            __builder.AddAttribute(128, "type", "text");
            __builder.AddAttribute(129, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 78 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                              Model.hops[selectedHopAddition].amount

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(130, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Model.hops[selectedHopAddition].amount = __value, Model.hops[selectedHopAddition].amount));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(131, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(132, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(133, "\r\n            ");
            __builder.OpenElement(134, "div");
            __builder.AddAttribute(135, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(136, "\r\n                ");
            __builder.AddMarkupContent(137, "<div class=\"col-1-4\">\r\n                    <label>Type</label>\r\n                </div>\r\n                ");
            __builder.OpenElement(138, "div");
            __builder.AddAttribute(139, "class", "col-3-4");
            __builder.AddMarkupContent(140, "\r\n                    ");
            __builder.OpenElement(141, "select");
            __builder.AddAttribute(142, "id", "HopTypeSelector");
            __builder.AddAttribute(143, "class", "ingredientSelector");
            __builder.AddAttribute(144, "style", "width:100%;");
            __builder.AddAttribute(145, "onchange", true);
            __builder.AddMarkupContent(146, "\r\n                        ");
            __builder.OpenElement(147, "option");
            __builder.AddAttribute(148, "value", "Boil");
            __builder.AddContent(149, "Boil");
            __builder.CloseElement();
            __builder.AddMarkupContent(150, "\r\n                        ");
            __builder.OpenElement(151, "option");
            __builder.AddAttribute(152, "value", "Whirlpool");
            __builder.AddContent(153, "Whirlpool");
            __builder.CloseElement();
            __builder.AddMarkupContent(154, "\r\n                        ");
            __builder.OpenElement(155, "option");
            __builder.AddAttribute(156, "value", "Dry Hop");
            __builder.AddContent(157, "Dry Hop");
            __builder.CloseElement();
            __builder.AddMarkupContent(158, "\r\n                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(159, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(160, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(161, "\r\n            ");
            __builder.OpenElement(162, "div");
            __builder.AddAttribute(163, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(164, "\r\n                ");
            __builder.AddMarkupContent(165, "<div class=\"col-1-4\">\r\n                    <label>time</label>\r\n                </div>\r\n                ");
            __builder.OpenElement(166, "div");
            __builder.AddAttribute(167, "class", "col-3-4");
            __builder.AddMarkupContent(168, "\r\n                    ");
            __builder.OpenElement(169, "input");
            __builder.AddAttribute(170, "type", "text");
            __builder.AddAttribute(171, "value", Microsoft.AspNetCore.Components.BindConverter.FormatValue(
#nullable restore
#line 98 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\HopWidget.razor"
                                              Model.hops[selectedHopAddition].time

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(172, "onchange", Microsoft.AspNetCore.Components.EventCallback.Factory.CreateBinder(this, __value => Model.hops[selectedHopAddition].time = __value, Model.hops[selectedHopAddition].time));
            __builder.SetUpdatesAttributeName("value");
            __builder.CloseElement();
            __builder.AddMarkupContent(173, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(174, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(175, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(176, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(177, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
