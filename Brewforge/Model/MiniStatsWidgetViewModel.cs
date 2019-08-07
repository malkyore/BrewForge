using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    public class MiniStatsWidgetViewModel
    {
       public string BrewlogName { get; set; }
       public recipe originalRecipe { get; set; }
       public recipe rectifiedRecipe { get; set; }
    }
}