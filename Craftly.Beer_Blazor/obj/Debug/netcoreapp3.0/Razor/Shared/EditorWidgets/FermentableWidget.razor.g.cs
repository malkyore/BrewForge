#pragma checksum "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0228b6f7d6e93a0f6025c7d4f0fe9cae72c40710"
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
#line 1 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
using Beernet_Lib.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 2 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
using Craftly.Beer_Blazor.ComponentClasses.EditorComponents;

#line default
#line hidden
#nullable disable
    public class FermentableWidget : FermentableEditor
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenElement(0, "div");
            __builder.AddAttribute(1, "id", "fermentableWidgetWrapper");
            __builder.AddAttribute(2, "class", "grid grid-pad widgetItem recipeEditorWidget");
            __builder.AddMarkupContent(3, "\r\n    ");
            __builder.OpenElement(4, "div");
            __builder.AddAttribute(5, "class", "col-1-2");
            __builder.AddMarkupContent(6, "\r\n        ");
            __builder.OpenElement(7, "div");
            __builder.AddAttribute(8, "id", "fermentableListSelector");
            __builder.AddAttribute(9, "class", "module selectorWidget");
            __builder.AddMarkupContent(10, "\r\n");
#nullable restore
#line 8 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
              
                if (Model.fermentables.Count != 0)
                {
                    int i = 0;
                    foreach (fermentableAddition fa in Model.fermentables)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(11, "                        ");
            __builder.OpenElement(12, "div");
            __builder.AddAttribute(13, "class", "hopListItem" + " grid" + " " + (
#nullable restore
#line 14 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                       i == selectedFermentableAddition ? "hopListItemSelected" : ""

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(14, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 14 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                                                                                 (() => changeSelectedFermentable(fa.additionGuid))

#line default
#line hidden
#nullable disable
            ));
            __builder.AddMarkupContent(15, "\r\n                            ");
            __builder.OpenElement(16, "div");
            __builder.AddAttribute(17, "class", "col-1-3");
            __builder.AddMarkupContent(18, "\r\n                                ");
            __builder.OpenElement(19, "div");
            __builder.AddContent(20, 
#nullable restore
#line 16 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                      fa.fermentable.name

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(21, "\r\n                                ");
            __builder.AddMarkupContent(22, "<div class=\"ingredientUnit\">name</div>\r\n                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(23, "\r\n                            ");
            __builder.OpenElement(24, "div");
            __builder.AddAttribute(25, "class", "col-1-3");
            __builder.AddMarkupContent(26, "\r\n                                ");
            __builder.OpenElement(27, "div");
            __builder.AddContent(28, 
#nullable restore
#line 20 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                      fa.fermentable.maltster

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(29, "\r\n                                ");
            __builder.AddMarkupContent(30, "<div class=\"ingredientUnit\">maltster</div>\r\n                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(31, "\r\n                            ");
            __builder.OpenElement(32, "div");
            __builder.AddAttribute(33, "class", "col-1-3");
            __builder.AddMarkupContent(34, "\r\n                                ");
            __builder.OpenElement(35, "div");
            __builder.AddContent(36, 
#nullable restore
#line 24 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                      fa.weight

#line default
#line hidden
#nullable disable
            );
            __builder.CloseElement();
            __builder.AddMarkupContent(37, "\r\n                                ");
            __builder.AddMarkupContent(38, "<div class=\"ingredientUnit\">lbs</div>\r\n                            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(39, "\r\n                        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(40, "\r\n");
#nullable restore
#line 28 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                        i++;
                    }
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
            __builder.AddAttribute(45, "class", "col-1-2");
            __builder.AddMarkupContent(46, "\r\n        ");
            __builder.OpenElement(47, "div");
            __builder.AddAttribute(48, "class", "module grid");
            __builder.AddMarkupContent(49, "\r\n            ");
            __builder.OpenElement(50, "div");
            __builder.AddAttribute(51, "class", "col-1-2");
            __builder.AddMarkupContent(52, "\r\n                ");
            __builder.OpenElement(53, "button");
            __builder.AddAttribute(54, "type", "button");
            __builder.AddAttribute(55, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 37 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                (() => AddFermentable())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(56, "Add Fermentable");
            __builder.CloseElement();
            __builder.AddMarkupContent(57, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(58, "\r\n            ");
            __builder.OpenElement(59, "div");
            __builder.AddAttribute(60, "class", "col-1-2");
            __builder.AddMarkupContent(61, "\r\n                ");
            __builder.OpenElement(62, "button");
            __builder.AddAttribute(63, "type", "button");
            __builder.AddAttribute(64, "onclick", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 40 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                (() => DeleteFermentable())

#line default
#line hidden
#nullable disable
            ));
            __builder.AddContent(65, "Delete Fermentable");
            __builder.CloseElement();
            __builder.AddMarkupContent(66, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(67, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(68, "\r\n        ");
            __builder.OpenElement(69, "div");
            __builder.AddAttribute(70, "class", "module editorWidget");
            __builder.AddMarkupContent(71, "\r\n            ");
            __builder.AddMarkupContent(72, "<h4 style=\"padding-top:0;\">Edit Fermentable</h4>\r\n            ");
            __builder.OpenElement(73, "div");
            __builder.AddAttribute(74, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(75, "\r\n                ");
            __builder.AddMarkupContent(76, "<div class=\"col-1-4 editorLabel\">\r\n                    <label>Fermentable: </label>\r\n                </div>\r\n                ");
            __builder.OpenElement(77, "div");
            __builder.AddAttribute(78, "class", "col-3-4");
            __builder.AddMarkupContent(79, "\r\n                    ");
            __builder.OpenComponent<Radzen.Blazor.RadzenDropDown<string>>(80);
            __builder.AddAttribute(81, "AllowClear", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 50 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                false

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(82, "LoadData", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Radzen.LoadDataArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Radzen.LoadDataArgs>(this, 
#nullable restore
#line 51 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                               LoadData

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(83, "AllowFiltering", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 51 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                         true

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(84, "Data", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Collections.IEnumerable>(
#nullable restore
#line 52 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                           FermentableList

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(85, "TextProperty", "name");
            __builder.AddAttribute(86, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 52 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                                        selectedFermentableID

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(87, "Placeholder", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 52 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                                                                             fermentableName

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(88, "ValueProperty", "idString");
            __builder.AddAttribute(89, "Style", "width:100%;");
            __builder.AddAttribute(90, "Change", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<System.Object>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<System.Object>(this, 
#nullable restore
#line 53 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                              args => Change(args, "DropDown with custom filtering")

#line default
#line hidden
#nullable disable
            )));
            __builder.CloseComponent();
            __builder.AddMarkupContent(91, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(92, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(93, "\r\n            ");
            __builder.OpenElement(94, "div");
            __builder.AddAttribute(95, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(96, "\r\n                ");
            __builder.AddMarkupContent(97, "<div class=\"col-1-4 editorLabel\">\r\n                    <label>PPG: </label>\r\n                </div>\r\n                ");
            __builder.OpenElement(98, "div");
            __builder.AddAttribute(99, "class", "col-3-4");
            __builder.AddMarkupContent(100, "\r\n");
#nullable restore
#line 61 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                     if (selectedFermentableAddition != -1 && Model.fermentables.Count != 0 && Model.fermentables[selectedFermentableAddition].fermentable != null)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(101, "                        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(102);
            __builder.AddAttribute(103, "Style", "width:100%;");
            __builder.AddAttribute(104, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 63 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                       args => ChangeFermentableYield(args.Value.ToString(), "TextBox with change on every input")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(105, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 63 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                                                                                                                             Model.fermentables[selectedFermentableAddition].fermentable.yield.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(106, "\r\n");
#nullable restore
#line 64 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(107, "                        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(108);
            __builder.AddAttribute(109, "Style", "width:100%;");
            __builder.AddAttribute(110, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 67 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                       args => ChangeFermentableYield(args.Value.ToString(), "TextBox with change on every input")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(111, "Value", "");
            __builder.CloseComponent();
            __builder.AddMarkupContent(112, "\r\n");
#nullable restore
#line 68 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(113, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(114, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(115, "\r\n            ");
            __builder.OpenElement(116, "div");
            __builder.AddAttribute(117, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(118, "\r\n                ");
            __builder.AddMarkupContent(119, "<div class=\"col-1-4 editorLabel\">\r\n                    <label>Type: </label>\r\n                </div>\r\n                ");
            __builder.OpenElement(120, "div");
            __builder.AddAttribute(121, "class", "col-3-4");
            __builder.AddMarkupContent(122, "\r\n                    ");
            __builder.OpenElement(123, "label");
            __builder.AddMarkupContent(124, "\r\n");
#nullable restore
#line 77 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                         if (selectedFermentableAddition != -1 && Model.fermentables.Count != 0)
                        {
                            

#line default
#line hidden
#nullable disable
            __builder.AddContent(125, 
#nullable restore
#line 79 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                             Model.fermentables[selectedFermentableAddition].fermentable.type

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 79 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                                             
                        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(126, "                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(127, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(128, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(129, "\r\n            ");
            __builder.OpenElement(130, "div");
            __builder.AddAttribute(131, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(132, "\r\n                ");
            __builder.AddMarkupContent(133, "<div class=\"col-1-4 editorLabel\">\r\n                    <label>Maltster: </label>\r\n                </div>\r\n                ");
            __builder.OpenElement(134, "div");
            __builder.AddAttribute(135, "class", "col-3-4");
            __builder.AddMarkupContent(136, "\r\n                    ");
            __builder.OpenElement(137, "label");
            __builder.AddMarkupContent(138, "\r\n");
#nullable restore
#line 90 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                         if (selectedFermentableAddition != -1 && Model.fermentables.Count != 0)
                        {
                            

#line default
#line hidden
#nullable disable
            __builder.AddContent(139, 
#nullable restore
#line 92 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                             Model.fermentables[selectedFermentableAddition].fermentable.maltster

#line default
#line hidden
#nullable disable
            );
#nullable restore
#line 92 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                                                 
                        }

#line default
#line hidden
#nullable disable
            __builder.AddContent(140, "                    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(141, "\r\n                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(142, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(143, "\r\n            ");
            __builder.OpenElement(144, "div");
            __builder.AddAttribute(145, "class", "editorListItem infogrid");
            __builder.AddMarkupContent(146, "\r\n                ");
            __builder.AddMarkupContent(147, "<div class=\"col-1-4 editorLabel\">\r\n                    <label>amount</label>\r\n                </div>\r\n                ");
            __builder.OpenElement(148, "div");
            __builder.AddAttribute(149, "class", "col-3-4");
            __builder.AddMarkupContent(150, "\r\n");
#nullable restore
#line 102 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                     if (selectedFermentableAddition != -1 && Model.fermentables.Count != 0)
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(151, "                        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(152);
            __builder.AddAttribute(153, "Style", "width:100%;");
            __builder.AddAttribute(154, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 104 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                       args => ChangeFermentableWeight(args.Value.ToString(), "TextBox with change on every input")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(155, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 104 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                                                                                                                              Model.fermentables[selectedFermentableAddition].weight.ToString()

#line default
#line hidden
#nullable disable
            ));
            __builder.CloseComponent();
            __builder.AddMarkupContent(156, "\r\n");
#nullable restore
#line 105 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                    }
                    else
                    {

#line default
#line hidden
#nullable disable
            __builder.AddContent(157, "                        ");
            __builder.OpenComponent<Radzen.Blazor.RadzenTextBox>(158);
            __builder.AddAttribute(159, "Style", "width:100%;");
            __builder.AddAttribute(160, "oninput", Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.ChangeEventArgs>(this, 
#nullable restore
#line 108 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                                                                       args => ChangeFermentableWeight(args.Value.ToString(), "TextBox with change on every input")

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(161, "Value", "");
            __builder.CloseComponent();
            __builder.AddMarkupContent(162, "\r\n");
#nullable restore
#line 109 "F:\_Repos\Craftly.beer_Blazor\Craftly.Beer_Blazor\Craftly.Beer_Blazor\Shared\EditorWidgets\FermentableWidget.razor"
                    }

#line default
#line hidden
#nullable disable
            __builder.AddContent(163, "                ");
            __builder.CloseElement();
            __builder.AddMarkupContent(164, "\r\n            ");
            __builder.CloseElement();
            __builder.AddMarkupContent(165, "\r\n        ");
            __builder.CloseElement();
            __builder.AddMarkupContent(166, "\r\n    ");
            __builder.CloseElement();
            __builder.AddMarkupContent(167, "\r\n");
            __builder.CloseElement();
        }
        #pragma warning restore 1998
    }
}
#pragma warning restore 1591
