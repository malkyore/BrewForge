using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Beernet_Lib.Models;

namespace Craftly.Beer_Blazor.ComponentClasses.EditorComponents
{
    public class HopEditor : ComponentBase
    {
        public static string operatorvalue = "";
        [Parameter]
        public recipe Model { get; set; }//= RecipeHelper.initializeBlankRecipe();
        public static int selectedHopAddition { get; set; } = 0;

    }
}
