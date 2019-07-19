using Beernet_Lib.Models;
using System;

namespace Brewforge.Models
{
    public class EditorViewModel
    {
        public recipe currentRecipe { get; set; }

        public hopAddition selectedHopAddition { get; set; }

        public int selectedHopIndex { get; set; }

        public fermentableAddition selectedFermentableAddition { get; set; }

        public int selectedFermentableIndex { get; set; }

    }
}