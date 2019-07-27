using Beernet_Lib.Models;
using System;
using System.Collections.Generic;

namespace Brewforge.Models
{
    public class HopEditorViewModel
    {
        public List<hopAddition> allHops { get; set; }
        
        public hopAddition selectedHopAddition { get; set; }

        public List<hopbase> hopOptions { get; set; }
    }
}