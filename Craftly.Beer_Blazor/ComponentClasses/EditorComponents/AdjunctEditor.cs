using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class AdjunctEditor : ComponentBase
    {
        [Parameter]
        public  recipe Model { get; set; }
        public static int selectedAdjunctAddition { get; set; } = 0;
    }
}
