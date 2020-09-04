using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Craftly.Beer_Blazor.ComponentClasses.ComponentStateClasses
{
    public class HopState
    {
        public string currentSelectedHopID { get; set; }
        public int currentSelectedHopIndex { get; set; }
    }

    public class FermentableState
    {
        public string currentSelectedFermentableID { get; set; }
        public int currentSelectedFermentableIndex { get; set; }
    }
    public class YeastState
    {
        public string currentSelectedYeastID { get; set; }
        public int currentSelectedYeastIndex { get; set; }
    }

    public class AdjunctState
    {
        public string currentSelectedAdjunctID { get; set; }
        public int currentSelectedAdjunctIndex { get; set; }
    }

    public class EditorState
    {
        public HopState hopstate { get; set; }
        public FermentableState fermentableState { get; set; }
        public YeastState yeastState { get; set; }
        public AdjunctState adjunctState { get; set; }
    }
}
