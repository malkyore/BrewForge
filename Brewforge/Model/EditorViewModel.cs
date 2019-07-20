using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    public class EditorViewModel
    {
        public recipe currentRecipe { get; set; }

        public hopAddition selectedHopAddition { get; set; }

        public int selectedHopIndex { get; set; }

        public fermentableAddition selectedFermentableAddition { get; set; }

        public int selectedFermentableIndex { get; set; }

        public List<hopbase> hopOptions { get; set; }

        public List<fermentable> fermentableOptions { get; set; }

        public int selectedFermentableAdditionIndex {get;set;}

        public int selectedHopAdditionIndex { get; set; }

    }
}