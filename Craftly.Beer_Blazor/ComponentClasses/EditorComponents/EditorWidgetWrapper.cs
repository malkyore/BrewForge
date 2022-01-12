using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;
using Radzen;
using Beernet_Lib.Tools;
using Craftly.Beer_Blazor.ComponentClasses.ComponentStateClasses;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class EditorWidgetWrapper : ComponentBase
    {
        [Parameter] public recipe Model { get; set; }
        [Parameter] public EventCallback<string> refreshParent { get; set; }
        [Parameter] public string SessionID { get; set; }
        [Parameter] public EditorState editorState { get; set; }
        //[Parameter] public YeastState yeastState { get; set; }
        //[Parameter] public AdjunctState adjunctState { get; set; }
        //[Parameter] public HopState hopState { get; set; }
        //[Parameter] public FermentableState fermentableState { get; set; }


    }
}